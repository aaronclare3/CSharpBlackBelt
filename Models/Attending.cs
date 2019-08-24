using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

    namespace Belt_exam.Models
    {
        public class Attending
        {
            [Key]
            public int AttendingId { get; set; }

            public int ThisActId {get;set;}
            public Act ThisAct {get;set;}
            public int ThisUserId {get;set;}
            public User ThisUser {get;set;}
            
            public DateTime CreatedAt {get;set;} = DateTime.Now;
            public DateTime UpdatedAt {get;set;} = DateTime.Now;
        }
    }