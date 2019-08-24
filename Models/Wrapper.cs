using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

    namespace Belt_exam.Models
    {
        public class Wrapper
        {
            public Act OneAct {get;set;}
            public List<Act> AllActs {get;set;}

            public User OneGuest {get;set;}
            public List<User> AllGuests {get;set;}
            public Attending OneAttending {get;set;}
            public List<Attending> AllAttending {get;set;}
            
        }
    }