using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


    namespace Belt_exam.Models
    {

        public class Future : ValidationAttribute {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
                DateTime today = DateTime.Today;
                string val = value.ToString();
                if(val == null) {
                    return new ValidationResult("Date is required");
                }
                if(DateTime.Parse(val) < today) {
                    return new ValidationResult("No dates allowed in the past");
                } else {
                    return ValidationResult.Success;
                }
            }
        }
        public class Act
        {
            // auto-implemented properties need to match the columns in your table
            // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
            [Key]
            public int ActId { get; set; }
            
            public int CoordinatorId{get;set;}
            public User Coordinator{get;set;}

            [Required]
            public string Title { get; set; }

            [Required]
            public DateTime Time { get; set; }

            [Required]
            [Future]

            public DateTime Date {get;set;}

            [Required]
            public int Duration {get;set;}
            public string DurationType {get;set;}

            [Required]
            public string Description {get;set;}

            public List<Attending> UsersAttending {get;set;}


            public DateTime CreatedAt {get;set;} = DateTime.Now;
            public DateTime UpdatedAt {get;set;} = DateTime.Now;

        }
    }