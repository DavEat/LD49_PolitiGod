using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Events
{
    public class EventManager : Singleton<EventManager>
    {


        void Start()
        {
            GameManager.inst.tick += OnTick;

            EventTab.inst.ShowEvent("Congratulations !", "Hi,\nYou just got elected new god of this charming little city.\nThe previous god in office didn't manage think correctly around here. His popularity and the city economy were very Unstable. ;)\nIt will be difficult but try to do your best to maintain citizens needs (Infos tab) and your Popularity to be reelected next time.\n\nYou can manage the city economy in the Finances tab and start projects in the Project tab.");
        }

        void OnTick(int cycleNumber)
        {
            if (cycleNumber == 45)
            {
                SoundManager.inst.PlayEvent0();
                EventTab.inst.ShowEvent("Student in need", "A student is praying very hard, he is not sure he will pass is exam and he would like some help from you.",
                    new Effect(GameManager.inst.numberOfCycles + 10, 30, new Dictionary<EffectOn, int>() { { EffectOn.heath, 30 }, { EffectOn.happiness, 1 } },
                        new Action(() => {
                            SoundManager.inst.PlayEvent0();
                            EventTab.inst.ShowEvent("Bad Doctor", "It appears that the student you helped pass his exam, as become a Doctor but wasn't qualified and had become one only beause of your help.\nThe result is that people died because of a wrong diagnostic.",
                            new Effect(GameManager.inst.numberOfCycles, 20, new Dictionary<EffectOn, int>() { { EffectOn.happiness, -5 }, { EffectOn.approbation, -5 } })
                        ); })
                    ),
                    new Effect(GameManager.inst.numberOfCycles, 20, new Dictionary<EffectOn, int>() { { EffectOn.happiness, -1 } })
                );
            }
            else if (cycleNumber == 120)
            {
                SoundManager.inst.PlayEvent0();
                EventTab.inst.ShowEvent("A Drought", "A farmer is asking that you make it rain.\nThere is a drought and she need water for her fields.",
                    new Effect(GameManager.inst.numberOfCycles + 5, 30, new Dictionary<EffectOn, int>() { { EffectOn.flood, 70 }, { EffectOn.happiness, 1 } },
                        new Action(() => {
                            SoundManager.inst.PlayEvent0();
                            EventTab.inst.ShowEvent("Too much Water", "It appears that you got heavy handed with the rain and nearly cause a flood.\nHopefully no one got hurt (this time)."
                            );
                        })
                    ),
                    new Effect(GameManager.inst.numberOfCycles, 20, new Dictionary<EffectOn, int>() { { EffectOn.happiness, -1 } })
                );
            }
            else if (cycleNumber == 170)
            {
                SoundManager.inst.PlayEvent0();
                EventTab.inst.ShowEvent("A Prophet ?", "Man is speaking on the town square saying that he talk in the name of the ruling god, the problem is that you don't know and have ever speak with him.\nOne of your council member is sugesting to strike him down.",
                    new Effect(GameManager.inst.numberOfCycles + 5, 30, new Dictionary<EffectOn, int>() { { EffectOn.approbation, 10 }, { EffectOn.crime, -10 } },
                        new Action(() => {
                            SoundManager.inst.PlayEvent0();
                            EventTab.inst.ShowEvent("Where are holy men", "Since you strike down that false prophet a lot of holy men have descided that they better no speak in the name of something they dont understand.\nThe problem is that we may miss a bit the peoples fervor."
                            );
                        })
                    ),
                    new Effect(GameManager.inst.numberOfCycles, 10, new Dictionary<EffectOn, int>() { { EffectOn.demonstration, 20 } },
                        new Action(() => {
                            SoundManager.inst.PlayEvent0();
                            EventTab.inst.ShowEvent("But it's just a man", "The false prophet have continued to speak to the people and some how he manage to for a crownn, which is holding grudge against me for some unknown reason.",
                                new Effect(GameManager.inst.numberOfCycles, 40, new Dictionary<EffectOn, int>() { { EffectOn.demonstration, 50 } })
                            );
                        })
                    )
                );
            }
        }

        public void WinElection()
        {
            SoundManager.inst.PlayElected0();
            EventTab.inst.ShowEvent("Election Won !", "Congratulations you won the election !\nApparently people does like you (for now).\nKeep up the good work.");
        }
        public void LoseElectionFirst()
        {
            SoundManager.inst.PlayLoseElected0();
            EventTab.inst.ShowEvent("Ho no Election Lost", "You lost your first election since you take office ?\nIt does not matter, the Big god like you and think you diserve a second chance.\nHe will help peoples to like you a bit more.\n\nHop Hop, return to your duties a do better at playing god.",
                new Effect(GameManager.inst.numberOfCycles, 30, new Dictionary<EffectOn, int>() { { EffectOn.approbation, 50 - InfosManager.inst.m_approbation }, { EffectOn.happiness, 10 } })
            );
        }
        public void LoseElection()
        {
            SoundManager.inst.PlayLoseElected0();
            EventTab.inst.ShowEvent("Election Lost !", "Apparently people does not like you...\nBut at least you kept some a the money for the Big god.\n\nPerhaps you should concider doing some thing else, where you an use your abilities to make money (for the Big god) ?");
        }
        public void LoseMoneyFirst()
        {
            SoundManager.inst.PlayLoseElected0();
            EventTab.inst.ShowEvent("Ho no Bankrupt", "You lost all the money of Big god, euhh of the city I means ?\nIt does matter, but the Big god like you and think you diserve a second chance.\nHe will help you by giving you abit of money.\n\nHop Hop, return to your duties a do better at playing god.");
            FinancesManager.inst.FreeeMoeny(1000);
        }
        public void LoseMoney()
        {
            SoundManager.inst.PlayLoseElected0();
            EventTab.inst.ShowEvent("Ho no Bankrupt again !", "Big god is more Angry god right now, you lost all is moeny twice !\nYour good to return working as filthy human on earth now\nByyye !");
        }
        public void LoseCrowd()
        {
            SoundManager.inst.PlayLoseElected0();
            EventTab.inst.ShowEvent("Over throne !", "A big angry crowd dreaming of a better futur, strom trough our office an put an end to your tyrannical reign !");
        }
        public void WinElectionFinal()
        {
            SoundManager.inst.PlayLoseElected0();
            EventTab.inst.ShowEvent("Needed by the people !", "Congratulation you manager to stay in office for a long time, your are very old and do not undustrand the changes of the world but it does not prevent you to continuing ruling as long as you earn money for the Big god.",
                new Effect(GameManager.inst.numberOfCycles, 1, new Dictionary<EffectOn, int>(), () => EndW())
            );
        }
        public void End()
        {
            SoundManager.inst.PlayElected0();
            EventTab.inst.ShowEvent("Thanks you !", "Thanks you for playing !\nGame Made by Nakami\nin 30 hours for the Ludum Dare 49");
        }
        public void EndW()
        {
            SoundManager.inst.PlayElected0();
            EventTab.inst.ShowEvent("Thanks you !", "Thanks you for playing !\nGame Made by Nakami\nin 30 hours for the Ludum Dare 49\n\nYou can continue playing the game but nothing new will happend\n\nDo you want to restart from the start ?",
                new Effect(GameManager.inst.numberOfCycles, 1, new Dictionary<EffectOn, int>(), () => SceneManager.LoadScene(0)),
                new Effect(GameManager.inst.numberOfCycles, 1, new Dictionary<EffectOn, int>())
            );
        }
    }
}