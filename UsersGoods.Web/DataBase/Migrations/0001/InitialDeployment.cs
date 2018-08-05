using FluentMigrator;
using System;

namespace UsersGoods.Web.DataBase.Migrations
{
    [Migration(20180804160000, "InitialDeployment")]
    public class InitialDeployment : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.Script(AppDomain.CurrentDomain.BaseDirectory + @"\DataBase\Migrations\0001\createdatabase.sql");
        }
    }
}