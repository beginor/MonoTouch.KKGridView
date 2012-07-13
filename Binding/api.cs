using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MonoTouch.KKGrid {
	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//
	// Once you've done that, you're ready to move on to binding the API...
	//
	//
	// Here is where you'd define your API definition for the native Objective-C library.
	//
	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     PointF Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//
	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_types
	//
	
//@protocol KKGridViewDataSource <NSObject>
	[BaseType(typeof(NSObject))]
	[Model]
	interface KKGridViewDataSource {
//@required
//- (NSUInteger)gridView:(KKGridView *)gridView numberOfItemsInSection:(NSUInteger)section;
		[Abstract, Export("gridView:numberOfItemsInSection:")]
		uint GetNumberOfItems(KKGridView gridView, uint section);
//- (KKGridViewCell *)gridView:(KKGridView *)gridView cellForItemAtIndexPath:(KKIndexPath *)indexPath;
		[Abstract, Export("gridView:cellForItemAtIndexPath:")]
		KKGridViewCell GetCell(KKGridView gridView, KKIndexPath indexPath);
//@optional
//- (NSUInteger)numberOfSectionsInGridView:(KKGridView *)gridView;
		[Export("numberOfSectionsInGridView:")]
		uint GetNumberOfSections(KKGridView gridView);
//- (NSString *)gridView:(KKGridView *)gridView titleForHeaderInSection:(NSUInteger)section;
		[Export("gridView:titleForHeaderInSection:")]
		string GetHeaderTitle(KKGridView gridView, uint section);
//- (NSString *)gridView:(KKGridView *)gridView titleForFooterInSection:(NSUInteger)section;
		[Export("gridView:titleForFooterInSection:")]
		string GetFooterTitle(KKGridView gridView, uint section);
//- (CGFloat)gridView:(KKGridView *)gridView heightForHeaderInSection:(NSUInteger)section;
		[Export("gridView:heightForHeaderInSection:")]
		float GetHeaderHeight(KKGridView gridView, uint section);
//- (CGFloat)gridView:(KKGridView *)gridView heightForFooterInSection:(NSUInteger)section;
		[Export("gridView:heightForFooterInSection:")]
		float GetFooterHeight(KKGridView gridView, uint section);
//- (UIView *)gridView:(KKGridView *)gridView viewForHeaderInSection:(NSUInteger)section;
		[Export("gridView:viewForHeaderInSection:")]
		UIView GetrHeader(KKGridView gridView, uint section);
//- (UIView *)gridView:(KKGridView *)gridView viewForFooterInSection:(NSUInteger)section;
		[Export("gridView:viewForFooterInSection:")]
		UIView GetFooter(KKGridView gridView, uint section);
//- (UIView *)gridView:(KKGridView *)gridView viewForRow:(NSUInteger)row inSection:(NSUInteger)section; // a row is compromised of however many cells fit in a column of a given section
		[Export("gridView:viewForRow:inSection:")]
		UIView GetViewForRow(KKGridView gridView, uint row, uint section);
//- (NSArray *)sectionIndexTitlesForGridView:(KKGridView *)gridView;
		[Export("sectionIndexTitlesForGridView:")]
		string[] GetSectionIndexTitles(KKGridView gridView);
//- (NSInteger)gridView:(KKGridView *)gridView sectionForSectionIndexTitle:(NSString *)title atIndex:(NSInteger)index;
		[Export("gridView:sectionForSectionIndexTitle:atIndex:")]
		int GetSection(KKGridView gridView, string title, int index);
//@end
	}

//@protocol KKGridViewDelegate <NSObject, UIScrollViewDelegate>
	[BaseType(typeof(UIScrollViewDelegate))]
	[Model]
	interface KKGridViewDelegate {
//@optional
//- (void)gridView:(KKGridView *)gridView didSelectItemAtIndexPath:(KKIndexPath *)indexPath;
		[Export("gridView:didSelectItemAtIndexPath:")]
		void DidSelectItem(KKGridView gridView, KKIndexPath indexPath);
//- (void)gridView:(KKGridView *)gridView didDeselectItemAtIndexPath:(KKIndexPath *)indexPath;
		[Export("gridView:didDeselectItemAtIndexPath:")]
		void DidDeselectItem(KKGridView gridView, KKIndexPath indexPath);
//- (KKIndexPath *)gridView:(KKGridView *)gridView willSelectItemAtIndexPath:(KKIndexPath *)indexPath;
		[Export("gridView:willSelectItemAtIndexPath:")]
		KKIndexPath WillSelectItem(KKGridView gridView, KKIndexPath indexPath);
//- (KKIndexPath *)gridView:(KKGridView *)gridView willDeselectItemAtIndexPath:(KKIndexPath *)indexPath;
		[Export("gridView:willDeselectItemAtIndexPath:")]
		KKIndexPath WillDeselectItem(KKGridView gridView, KKIndexPath indexPath);
//- (void)gridView:(KKGridView *)gridView willDisplayCell:(KKGridViewCell *)cell atIndexPath:(KKIndexPath *)indexPath;
		[Export("gridView:willDisplayCell:atIndexPath:")]
		void WillDisplayCell(KKGridView gridView, KKGridViewCell cell, KKIndexPath indexPath);
//@end
	}
	

//@interface KKGridView : UIScrollView
	[BaseType(typeof(UIScrollView))]
	interface KKGridView {
//#pragma mark - Properties

//@property (nonatomic) BOOL allowsMultipleSelection;
		[Export("allowsMultipleSelection")]
		bool AllowsMultipleSelection { get; set; }
//@property (nonatomic, strong) UIView *backgroundView;
		[Export("backgroundView")]
		UIView BackgroundView { get; set; }
//@property (nonatomic) CGSize cellPadding;
		[Export("cellPadding")]
		SizeF CellPadding { get; set; }
//@property (nonatomic) CGSize cellSize;
		[Export("cellSize")]
		SizeF CellSize { get; set; }
//@property (nonatomic, strong) UIView *gridFooterView;
		[Export("gridFooterView")]
		UIView GridFooterView { get; set; }
//@property (nonatomic, strong) UIView *gridHeaderView;
		[Export("gridHeaderView")]
		UIView GridHeaderView { get; set; }
//@property (nonatomic, readonly) NSUInteger numberOfColumns;
		[Export("numberOfColumns")]
		uint NumberOfColumns { get; }
//@property (nonatomic, readonly) NSUInteger numberOfSections;
		[Export("numberOfSections")]
		uint NumberOfSections { get; }

//#pragma mark - Data Source and Delegate
//@property (nonatomic, kk_weak) IBOutlet id <KKGridViewDataSource> dataSource;
		[Export("dataSource")]
		NSObject WeakDataSource { get; set; }
		
		[Wrap("WeakDataSource")]
		KKGridViewDataSource DataSource { get; set; }
//@property (nonatomic, kk_weak) IBOutlet id <KKGridViewDelegate> delegate;
		[Export("delegate")]
		NSObject WeakDelegate { get; set; }
		
		[Wrap("WeakDelegate")]
		KKGridViewDelegate Delegate { get; set; }

//#pragma mark - Getters

//- (KKGridViewCell *)dequeueReusableCellWithIdentifier:(NSString *)identifier;
		[Export("dequeueReusableCellWithIdentifier:")]
		KKGridViewCell DequeueReusableCell(string identifier);
//- (CGRect)rectForCellAtIndexPath:(KKIndexPath *)indexPath;
		[Export("rectForCellAtIndexPath:")]
		RectangleF RectForCell(KKIndexPath indexPath);
//- (NSArray *)visibleIndexPaths;
		[Export("visibleIndexPaths")]
		KKIndexPath[] GetVisibleIndexPaths();

//- (KKIndexPath *)indexPathForCell:(KKGridViewCell *)cell;
		[Export("indexPathForCell:")]
		KKIndexPath GetIndexPath(KKGridViewCell cell);
//- (KKIndexPath *)indexPathForItemAtPoint:(CGPoint)point;
		[Export("indexPathForItemAtPoint:")]
		KKIndexPath GetIndexPath(PointF point);
//- (NSArray *)indexPathsForItemsInRect:(CGRect)rect;
		[Export("indexPathsForItemsInRect:")]
		KKIndexPath[] GetIndexPaths(RectangleF rect);

//#pragma mark - Reloading

//- (void)reloadContentSize;
		[Export("reloadContentSize")]
		void ReloadContentSize();
//- (void)reloadData;
		[Export("reloadData")]
		void ReloadData();

//#pragma mark - Items

//- (void)reloadItemsAtIndexPaths:(NSArray *)indexPaths;
		[Export("reloadItemsAtIndexPaths:")]
		void ReloadItems(KKIndexPath[] indexPaths);
//- (void)insertItemsAtIndexPaths:(NSArray *)indexPaths withAnimation:(KKGridViewAnimation)animation;
		[Export("insertItemsAtIndexPaths:withAnimation:")]
		void InsertItems(KKIndexPath[] indexPaths, KKGridViewAnimation animation);
//- (void)deleteItemsAtIndexPaths:(NSArray *)indexPaths withAnimation:(KKGridViewAnimation)animation;
		[Export("deleteItemsAtIndexPaths:withAnimation:")]
		void DeleteItems(KKIndexPath[] indexPaths, KKGridViewAnimation animation);
////- (void)moveItemAtIndexPath:(KKIndexPath *)indexPath toIndexPath:(KKIndexPath *)newIndexPath;
//- (void)scrollToItemAtIndexPath:(KKIndexPath *)indexPath animated:(BOOL)animated position:(KKGridViewScrollPosition)scrollPosition;
		[Export("scrollToItemAtIndexPath:animated:position")]
		void ScrollToItem(KKIndexPath indexPath, bool animated, KKGridViewScrollPosition scrollPosition);

//#pragma mark - Unimplemented

////- (void)insertSections:(NSIndexSet *)sections withItemAnimation:(KKGridViewAnimation)animation;
////- (void)deleteSections:(NSIndexSet *)sections withItemAnimation:(KKGridViewAnimation)animation;
////- (void)reloadSections:(NSIndexSet *)sections withAnimation:(KKGridViewAnimation)animation;


//#pragma mark - Selection

//- (void)selectItemsAtIndexPaths:(NSArray *)indexPaths animated:(BOOL)animated;
		[Export("selectItemsAtIndexPaths:animated:")]
		void SelectItems(KKIndexPath[] indexPaths , bool animated);
//- (void)deselectItemsAtIndexPaths:(NSArray *)indexPaths animated:(BOOL)animated;
		[Export("deselectItemsAtIndexPaths:animated:")]
		void DeselectItems(KKIndexPath[] indexPaths, bool animated);
//- (void)deselectAll: (BOOL)animated;
		[Export("deselectAll:")]
		void DeselectAll(bool animated);
//- (NSUInteger)selectedItemCount;
		[Export("selectedItemCount")]
		uint SelectedItemCount();

//- (KKIndexPath *)indexPathForSelectedCell;
		[Export("indexPathForSelectedCell")]
		KKIndexPath GetIndexPathForSelectedCell();
//- (NSArray *)indexPathsForSelectedCells;
		[Export("indexPathsForSelectedCells")]
		KKIndexPath[] GetIndexPathsForSelectedCells();
		
	}
//@end


//@interface KKGridViewCell : UIView
	[BaseType(typeof(UIView))]
	interface KKGridViewCell {
//#pragma mark - Class Methods

//+ (NSString *)cellIdentifier;
		[Static, Export("cellIdentifier")]
		string GetCellIdentifier();

//#pragma mark - Designated Initializer

//+ (id)cellForGridView:(KKGridView *)gridView;
		[Static, Export("cellForGridView:")]
		KKGridViewCell GetCell(KKGridView gridView);
//- (id)initWithFrame:(CGRect)frame reuseIdentifier:(NSString *)reuseIdentifier;
		[Export("initWithFrame:reuseIdentifier:")]
		IntPtr Constructor(RectangleF frame, string resuseIdentifier);

//#pragma mark - Properties

//@property (nonatomic, strong) IBOutlet UIView *backgroundView; // Underneath contentView, use this to customize backgrounds
		[Export("backgroundView")]
		UIView BackgroundView { get; set; }
//@property (nonatomic, strong) IBOutlet UIView *contentView; // Where all subviews should be.
		[Export("contentView")]
		UIView ContentView { get; set; }
//@property (nonatomic, strong) IBOutlet UIImageView *imageView;
		[Export("imageView")]
		UIImageView ImageView { get; set; }
//@property (nonatomic, copy) KKIndexPath *indexPath;
		[Export("indexPath", ArgumentSemantic.Copy)]
		KKIndexPath IndexPath { get; set; }
//@property (nonatomic, copy) NSString *reuseIdentifier; // For usage by KKGridView
		[Export("reuseIdentifier", ArgumentSemantic.Copy)]
		string ResuseIdentifier { get; set; }
//@property (nonatomic, getter = isSelected) BOOL selected;
		[Export("selected")]
		bool Selected { [Bind("isSelected")]get; set; }
//@property (nonatomic, getter = isHighlighted) BOOL highlighted;
		[Export("highlighted")]
		bool Highlighted { [Bind("isHighlighted")]get; set; }
//@property (nonatomic, strong) IBOutlet UIView *selectedBackgroundView; // Replaces *backgroundView when selected is YES
		[Export("selectedBackgroundView")]
		UIView SelectedBackgroundView { get; set; }
//@property (nonatomic) BOOL editing; // Editing state
		[Export("editing")]
		bool Editing { get; set; }
//@property (nonatomic) KKGridViewCellAccessoryType accessoryType; // Default is none.
		[Export("accessoryType")]
		KKGridViewCellAccessoryType AccessoryType { get; set; }
//@property (nonatomic) KKGridViewCellAccessoryPosition accessoryPosition; // Default is quadrant 1.
		[Export("accessoryPosition")]
		KKGridViewCellAccessoryPosition AccessoryPosition { get; set; }
//@property (nonatomic) float highlightAlpha; // Default is 1.0f
		[Export("highlightAlpha")]
		float HighlightAlpha { get; set; }

//- (void)setSelected:(BOOL)selected animated:(BOOL)animated;
		[Export("setSelected:animated:")]
		void SetSelected(bool selected, bool animated);
//- (void)setEditing:(BOOL)editing animated:(BOOL)animated;
		[Export("setEditing:animated:")]
		void SetEditing(bool editing, bool animated);
//#pragma mark - Subclassers

//- (void)prepareForReuse;
		[Export("prepareForReuse")]
		void PrepareForReuse();
	}
//@end
	

//@interface KKIndexPath : NSObject <NSCopying>
	[BaseType(typeof(NSObject))]
	interface KKIndexPath /*: NSCopying */ {
//+ (KKIndexPath *)zeroIndexPath;
		[Static, Export("zeroIndexPath")]
		KKIndexPath Zero();
//+ (NSArray *)indexPathsWithNSIndexPaths:(NSArray *)indexPaths;
		[Static, Export("indexPathsWithNSIndexPaths:")]
		KKIndexPath[] FromNSIndexPaths();

//- (id)initWithIndex:(NSUInteger)index section:(NSUInteger)section;
		[Export("initWithIndex:section:")]
		IntPtr Constructor(uint index, uint section);
//+ (id)indexPathForIndex:(NSUInteger)index inSection:(NSUInteger)section;
		[Static, Export("indexPathForIndex:inSection:")]
		KKIndexPath GetIndexPath(uint index, uint section);

//- (id)initWithNSIndexPath:(NSIndexPath *)indexPath;
		[Export("initWithNSIndexPath:")]
		IntPtr Constructor(NSIndexPath indexPath);
//+ (id)indexPathWithNSIndexPath:(NSIndexPath *)indexPath;
		[Static, Export("indexPathWithNSIndexPath:")]
		KKIndexPath FromNSIndexPath(NSIndexPath indexPath);

//- (NSIndexPath *)NSIndexPath;
		[Export("NSIndexPath")]
		NSIndexPath ToNSIndexPath();

//- (NSComparisonResult)compare:(id)other;
		[Export("compare:")]
		int Compare(KKIndexPath other);

//@property (nonatomic, readwrite) NSUInteger section;
		[Export("section")]
		uint Section { get; set; }
//@property (nonatomic, readwrite) NSUInteger index;
		[Export("index")]
		uint Index { get; set; }

//@end
	}
/*	
//@interface KKGridViewController : UIViewController <KKGridViewDataSource, KKGridViewDelegate>
	[BaseType(typeof(UIViewController))]
	interface KKGridViewController : KKGridViewDataSource, KKGridViewDelegate {
	
//@property (nonatomic, strong) KKGridView *gridView;
		[Export("gridView")]
		KKGridView GridView { get; set; }

		[Export("gridView:numberOfItemsInSection:")]
		uint GetNumberOfItems(KKGridView gridView, uint section);

		[Export("gridView:cellForItemAtIndexPath:")]
		KKGridViewCell GetCell(KKGridView gridView, KKIndexPath indexPath);

//@end
	}
*/
}

