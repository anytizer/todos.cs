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
    
    public partial class v_todos
    {
        public string user_id { get; set; }
        public string user_username { get; set; }
        public string user_fullname { get; set; }
        public string todo_id { get; set; }
        public string project_id { get; set; }
        public string project_name { get; set; }
        public string status_id { get; set; }
        public string status_name { get; set; }
        public System.DateTime added_on { get; set; }
        public string issue_number { get; set; }
        public string todo_text { get; set; }
    }
}
