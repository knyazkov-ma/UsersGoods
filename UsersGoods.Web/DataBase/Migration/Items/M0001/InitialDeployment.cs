using FluentMigrator;
using System;

namespace UsersGoods.Web.DataBase.Migration.Items
{
    [Migration(20180804160000, "InitialDeployment")]
    public class InitialDeployment : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.Script(AppDomain.CurrentDomain.BaseDirectory + @"\DataBase\Migration\Items\M0001\createdatabase.sql");
        }
    }
}