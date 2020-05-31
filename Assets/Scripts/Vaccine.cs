using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VaccineClass {
    public class Vaccine
    {
        private int type;
        private int[] additionalIngredients;

        public int progressMade = 0;
        private int requiredProgress = 60;
        public bool finishedDevelopment = false;

        public bool finishedPhase1 = false;
        public int phase1Days = 0;
        public int phase1DaysRequired = 30;

        public bool finishedPhase2 = false;
        public int phase2Days = 0;
        public int phase2DaysRequired = 60;

        public bool productionReady = false;
        public int phase3Days = 0;
        public int phase3DaysRequired = 100;

        public bool vaccineFailed = false;


        private System.Random rand = new System.Random();

        public Vaccine(int vaccineType, int[] ingredients) {
            type = vaccineType;
            additionalIngredients = ingredients;
        
        }

        public void IncreaseProgress() {
            if (rand.Next(10) < 6) {
                progressMade += 1;
            }

            if (progressMade > requiredProgress) {
                finishedDevelopment = true;
            }
        }

        public void Phase1() {
            if (type == 1) {
                if (additionalIngredients.Contains(1) && additionalIngredients.Contains(2)) {
                    phase1Days += 1;
                } else {
                    if (rand.Next(100) > 25) {
                        phase1Days += 1;
                    } else {
                        vaccineFailed = true;
                    }
                }
            } else {
                if (rand.Next(100) > 40) {
                    phase1Days += 1;
                } else {
                    vaccineFailed = true;
                }
            }

            if (!vaccineFailed && phase1Days > phase1DaysRequired){
                finishedPhase1 = true;
            }
        }

        public void Phase2() {
            if (type == 1) {
                if (additionalIngredients.Contains(1) && additionalIngredients.Contains(2)) {
                    phase2Days += 1;
                } else {
                    if (rand.Next(100) > 10) {
                        phase2Days += 1;
                    } else {
                        vaccineFailed = true;
                    }
                }
            } else {
                if (rand.Next(100) > 20) {
                    phase2Days += 1;
                } else {
                    vaccineFailed = true;
                }
            }

            if (!vaccineFailed && phase2Days > phase2DaysRequired) {
                finishedPhase2 = true;
            }
        }

        public void Phase3() {
            if (type == 1) {
                if (additionalIngredients.Contains(1) && additionalIngredients.Contains(2)) {
                    phase3Days += 1;
                } else {
                    if (rand.Next(100) > 25) {
                        phase3Days += 1;
                    } else {
                        vaccineFailed = true;
                    }
                }
            } else {
                if (rand.Next(100) > 40) {
                    phase3Days += 1;
                } else {
                    vaccineFailed = true;
                }
            }

            if (!vaccineFailed && phase3Days > phase3DaysRequired) {
                productionReady = true;
            }
        }
    }
}
