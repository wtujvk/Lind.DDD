//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lind.DDD.UnitTest
{
    using System;
    using System.Collections.Generic;
    
    public partial class WebManageRoles_WebManageMenus_Authority_R :Lind.DDD.Domain.IEntity
    {
        public int ID { get; set; }
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public int Authority { get; set; }
        public System.DateTime DataCreateDateTime { get; set; }
        public System.DateTime DataUpdateDateTime { get; set; }
        public int DataStatus { get; set; }
    
        public virtual WebManageMenus WebManageMenus { get; set; }
        public virtual WebManageRoles WebManageRoles { get; set; }
    }
}
