//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace database.mysql
{
    using System;
    using System.Collections.Generic;
    
    public partial class todo_projects_todos
    {
        public string project_id { get; set; }
        public string todo_id { get; set; }
        public System.DateTime added_on { get; set; }
    
        public virtual todo_projects todo_projects { get; set; }
        public virtual todo_todos todo_todos { get; set; }
    }
}