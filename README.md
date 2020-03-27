# USBCopyer: 插上U盘自动按需复制文件   

**用于在插上目标U盘后自动按需复制该U盘的文件。"备份&偷U盘文件的神器"**            
特点：
1. 支持设置冲突解决方案
2. 支持选择性复制，包括扩展名黑白名单、磁盘黑白名单。磁盘黑白名单支持序列号   
白名单模式结合版本控制可以方便地备份U盘
3. 支持隐藏模式及开机启动
4. **支持设置回调**，可以自己编写代码实现某种高级的、程序没有提供的功能。    
默认提供**Git版本控制支持**
5. 支持限制文件大小，防止复制大文件造成延误
6. 支持延迟复制，对“偷”课件类的场景提升用户体验十分有用

![Screenshot](/git-resources/screenshot-new.jpg)

本程序有两个图标，默认图标表示当前处于空闲状态，红色图标表示当前正在复制文件（工作中）          
   
现已提供三个版本（标准版/兼容版）可供下载，见“已编译版本下载”节      
[捐赠墙(点击查看)](Donors.md)
## 已编译版本下载

#### 【推荐】.Net Framework 4.0 版本（标准版）        
**适用操作系统**：Windows 8 / Windows 10     
[点击从Git@OSC下载(中国大陆用户推荐)](https://git.oschina.net/kenvix/USBCopyer/raw/master/Release/USBCopyer.Release.exe)         [点击从GitHub下载](https://github.com/kenvix/USBCopyer/blob/master/Release/USBCopyer.Release.exe?raw=true)  

#### .Net Framework 3.5 版本（兼容版）     
**适用操作系统**：Windows 7 / Windows Vista / Windows XP     
**WinXP请注意**：XP可能需要手动安装 .NET Framework 3.5，[没有安装请点此](https://download.microsoft.com/download/7/0/3/703455ee-a747-4cc8-bd3e-98a615c3aedb/dotNetFx35setup.exe)    
[点击从Git@OSC下载(中国大陆用户推荐)](https://git.oschina.net/kenvix/USBCopyer/raw/master/Release/USBCopyer.Release.Net3.5.exe)         [点击从GitHub下载](https://github.com/kenvix/USBCopyer/blob/master/Release/USBCopyer.Release.Net3.5.exe?raw=true)   


自 V5.0 开始，标准版即为低权限版。不会弹出UAC警告。亦支持高DPI缩放。
### 适用场景

1. 获取授课教师的课件         
2. 获取插到某台公用电脑上的U盘的数据
3. 快捷地备份U盘（从V5.0开始）         
4. 备份U盘的同时进行版本控制

#### 如何使用

1.下载
2.双击 USBCopyer.exe
3.程序将在托盘区运行，右击图标可以调整其参数
  点击 "隐藏图标" 将彻底隐藏程序，只能使用任务管理器停止，或按Win+R输入taskkill /f /im USBCopyer.exe
  点击 "设置" 可以设置程序

#### 命令行
USBCopyer.exe [/hide] [/gui] [/reset]          
/hide  以隐藏模式启动，只能通过任务管理器结束进程    
/gui   除非使用 /hide 参数，否则无论如何都不要使用隐藏模式启动。可用来解除隐藏模式
/reset 恢复默认设置并退出，若失败，返回退出码1。可用来解除隐藏模式，但会丢掉所有设置

### 常见问题
##### USBCopyer的复制行为造成U盘的文件操作卡顿
请设置一个延迟。通常推荐在使用者开始放映幻灯片时开始复制

##### 使用者在使用该电脑前重启了此电脑
将本程序设为开机启动即可。设置方法如下：
1. 直接在本程序的“设置”中设置
2. 若上面的方法无效，则可：   
   创建一个快捷方式，然后加上参数，拖到 "开始菜单" 的 "启动" 文件夹即可

##### 可否复制手机的文件？
若为MTP/PTP则无法实现（V6.0也许会实现），但如果是以Mass Storage(大容量存储)模式挂载到电脑上的设备则可以复制

##### U盘在操作完成前被拔出
请使用心理学方法防止U盘在操作完成前被拔出

##### 如何防止拷到病毒？
安装杀毒软件，监控 USBCopyerData 目录即可

##### 目标电脑带有还原机制
两种方法：       
1.插上你的U盘，然后启动本程序，加入该U盘到黑名单，然后设置输出目录到你的U盘         
2.用 PCHunter 之类的程序干掉还原程序

#### 如何使用回调&如何配置Git版本控制？
参见：https://kenvix.com/post/usbcopyer-callback/

## 代码仓库
[Git@OSC](https://git.oschina.net/kenvix/USBCopyer) [GitHub](https://github.com/kenvix/USBCopyer)            
[我的博客文章](https://kenvix.com/?p=86)

## 捐赠
USBCopyer 是一个开源的，非盈利的项目。如果你喜欢这个项目，请捐赠它：
##### 支付宝捐赠

![Screenshot](/git-resources/alipay-pay.jpg)

##### 微信支付捐赠
![Screenshot](/git-resources/weixin-pay.jpg)     
    
[捐赠墙(点击查看)](/Donors.md)