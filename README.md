# Luna.Service
一个命令行程序的框架

# Package
NuGet1: Install-Package Luna.Service

NuGet2: Install-Package Luna.Service.Nlog

# 关于使用
1. 如果你也使用nlog写日志的话可以直接引用 Luna.Service.Nlog 包.关于日志的一个配置会自动加载到项目中
2. 设置NLog.config文件编译时复制到输出目录
2. 在Main方法中新增代码
    ```
    using (var starter = Starter.Create<Runner>())
    {
    	starter.Container.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));
    
    	starter.Run();
    }
    ```
1. 增加你的service像下面这样
    ```
    public interface IDemoService : ILunaService
    {
    	string GetMessage();
    }
    
    public class DemoService : LunaServiceBase, IDemoService
    {
    	public string GetMessage()
    	{
    		Logger.Info("GetMessage");
    		return "测试";
    	}
    }
    ```
    注意接口实现ILunaService才能被自动注册进IOC
3. 修改Runner类的run方法
    ```
    public class Runner : LunaRunnerBase
    {
    	private readonly IDemoService _demoService;
    
    	public Runner(IDemoService demoService)
    	{
    		_demoService = demoService;
    	}
    
    	public override void Run()
    	{
    		var message = _demoService.GetMessage();
    		Logger.Info(message);
    		Logger.Info("ok");
    	}
    }
    ```

如果不喜欢用nlog的话,可以查看Castle.Windsor文档修改第3步中AddFacility方法

**项目约定: 你的程序命名必须遵循aaa.bb.c的方式**
> Demo.App        <- 应用程序入口

> Demo.Service    <- 服务层

> Demo.Entity     <- 实体层

