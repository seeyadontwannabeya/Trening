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
            days = int.Parse(prg.Trainingdays[0].ToString());
        }

        public string GenerateSchema()
        {
            if(days < 3 || experience == "First time")
            {
                workoutType = $"Fullbody Workout <br> Deadlifts (Ramped)  3 set    12 reps <br> Romanian Deadlift   3 set    12 reps <br> Seated Overhead Press   3 set    12 reps <br> Pull Ups or Inverted Rows 3 set  12 reps <br> Dips    3 set    12 reps <br> Barbell Shrugs 3 set     12 reps <br> Standing or Seated Calf Raise   3 set    12 reps <br> Plank   3   60 seconds";

            }
            else if (days == 3 || experience == "Less than a year") {

                workoutType = $"push pull program <br>  Day 1 <br> Chest Workout <br> Dumbbell Flye    3 set    12 reps <br> Superset: Incline Bench Press & Elevated Push Ups   3 set   12 reps <br> Superset: Dumbbell Incline Bench Press &Pec Dec    3 set   12 reps <br> Superset: Dumbbell Bench Press & Dumbbell Flye     3 set   12 reps <br> <br> Day 2 <br> Back Workout<br> Pull Down    3 set    12 reps <br> Bent Over Row    3 set   12 reps <br> Seated Cable Row    3 set    12 reps   <br> One Arm Dumbbell Row     3 set   12 reps   <br> High Hammer Strength Pull Down   3 set   12 reps   <br> Deadlifts 3 set  12 reps<br> <br>     Day 3 <br> Shoulder Workout       <br> Side Laterals - Ramping Tri - Set    3 set    12 reps         <br> Seated Dumbbell Overhead Press      3 set ";

            }
            else
            {
                workoutType = $" Day 1 <br> Chest Workout <br> Dumbbell Flye    3 set    12 reps <br> Superset: Incline Bench Press & Elevated Push Ups   3 set   12 reps <br> Superset: Dumbbell Incline Bench Press &Pec Dec    3 set   12 reps <br> Superset: Dumbbell Bench Press & Dumbbell Flye     3 set   12 reps <br> <br> Day 2 <br> Back Workout<br> Pull Down    3 set    12 reps <br> Bent Over Row    3 set   12 reps <br> Seated Cable Row    3 set    12 reps   <br> One Arm Dumbbell Row     3 set   12 reps   <br> High Hammer Strength Pull Down   3 set   12 reps   <br> Deadlifts 3 set  12 reps<br> <br>     Day 3 <br> Shoulder Workout       <br> Side Laterals - Ramping Tri - Set    3 set    12 reps         <br> Seated Dumbbell Overhead Press      3 set   12 reps  <br> Front Barbell Raise     3 set   12 reps          <br> Smith Machine Overhead Press    3 set   12 reps   <br> Bent Over Reverse Lateral   3 set   12 reps         <br> Behind the Neck Push Press      3 set   12 reps          <br> Cable Side Lateral      3 set   12 reps          <br> Front Cable Raise  3 set    12 reps          <br> Reverse Cable Crossovers -Rear Delts  3 set    12 reps         <br> Behind the Back Barbell Shrug  3 set    12 reps<br> <br>         Day 5        <br> Legs        <br> Leg Extensions     3 set   12 reps          <br> Leg Press  3 set    12 reps           <br> Squats     3 set    12 reps          <br> Leg Extension   3 set   12 reps          <br> Hack Squats or Front Squats    3 set    12 reps          <br> Leg Curl    3 set   12 reps          <br> Dumbbell Stiff Leg Deadlifts   3 set    12 reps          <br> Single Leg Curl     3 set   12 reps<br>          <br> Day 6     <br> Biceps and Triceps Workout              <br> Cable Curl & Rope Triceps Extension     3 set   12 reps              <br> Barbell Curl & Close Grip Bench Press   3 set   12 reps              <br> Seated Incline Dumbbell Curl & Overhead Dumbbell Triceps Extension     3 set    12 reps               <br> Seated Cable Curls &Dumbbell Kick Backs    3 set   12 reps              <br> Standing Two Arm Dumbbell Curls &Dips      3 set   12 reps";          
            }


            return workoutType;
        }

    }
}