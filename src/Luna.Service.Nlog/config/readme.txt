使用方法:

1.设置NLog.config编译时复制到输出目录
2.在Main方法中新增代码
using (var starter = Starter.Create<Runner>())
{
	starter.Container.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));

	starter.Run();
}

3.修改Runner类

注意: 项目要遵循aaa.bb.c命名规则.例如
Demo.App        <- 应用程序入口
Demo.Service    <- 服务层
Demo.Entity     <- 实体层