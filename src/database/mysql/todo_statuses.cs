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
    
    public partial class todo_statuses
    {
        public todo_statuses()
        {
            this.todo_projects_statuses = new HashSet<todo_projects_statuses>();
            this.todo_todos = new HashSet<todo_todos>();
        }
    
        public string status_id { get; set; }
        public string status_code { get; set; }
        public string status_shortname { get; set; }
        public string status_name { get; set; }
        public string is_active { get; set; }
        public string in_menu { get; set; }
        public long status_priority { get; set; }
    
        public virtual ICollection<todo_projects_statuses> todo_projects_statuses { get; set; }
        public virtual ICollection<todo_todos> todo_todos { get; set; }
    }
}
