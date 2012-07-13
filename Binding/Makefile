# 定义一些常量
PROJECT_ROOT=KKGridView
PROJECT=$(PROJECT_ROOT)/$(PROJECT_ROOT).xcodeproj
BUILD_ROOT=$(PROJECT_ROOT)/Build
TARGET=$(PROJECT_ROOT)
SDK=lib$(TARGET).a
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
XBUILD=xcodebuild

# 从github获取源代码
$(PROJECT_ROOT):
	git clone https://github.com/kolinkrewinkel/$(PROJECT_ROOT).git
	cd $(PROJECT_ROOT) && git pull

# 编译模拟器版本
simulator: $(PROJECT_ROOT)
	mkdir -p libs
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	mv -f $(BUILD_ROOT)/Release-iphoneSimulator/lib$(TARGET).a ./libs/lib$(TARGET)-simulator.a

# 编译设备版本
iphoneos: $(PROJECT_ROOT)
	mkdir -p libs
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -configuration Release clean build
	mv -f $(BUILD_ROOT)/Release-iphoneos/lib$(TARGET).a ./libs/lib$(TARGET)-iphoneos.a

# 讲两个版本合成为一个
sdk:
	lipo -create -output $(SDK) libs/lib$(TARGET)-simulator.a libs/lib$(TARGET)-iphoneos.a

# 编译 MonoTouch 组件
asm:
# 使用 btouch 编译出的 dll 文件总是无法运行， 不知是怎么回事， 只能用 MonoDevelop 进行编译， 所以把这里注释掉了。
# bash$ /Developer/MonoTouch/usr/bin/btouch -e cocos2d.cs -s:enums.cs -x:extensions.cs
#	$(BTOUCH) -e api.cs -s:enum.cs --link-with=$(SDK),$(SDK) -out:bin/$(TARGET).dll

# 清理
clean:
	rm -rf $(PROJECT_ROOT) libs ios *.a *.dll *.stamp

# 全部任务
all: clean simulator iphoneos sdk asm