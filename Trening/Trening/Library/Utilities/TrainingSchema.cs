using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trening.Models;

namespace Trening.Library.Utilities
{
    public class TrainingSchema
    {
        public string experience;
        public int days;
        public string workoutType;
        public TrainingSchema(Trainingprogram prg)
        {
            experience = prg.TrainingExperience;
            days = prg.Trainingdays[0];
        }

        public string GenerateSchema()
        {
            if(days < 3 || experience == "First time")
            {
                workoutType = "fullbody";
      
            }
            else if (days == 3 || experience == "Less than a year") {

                workoutType = "push pull legs";

            }
            else
            {
                workoutType = "brosplit";
            }


            return workoutType;
        }

    }
}