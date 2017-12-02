using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject();

            new TempObserverInCelcijus(subject);
            new TempObserverInFahrenheit(subject);

            Console.WriteLine("First");
            subject.SetState(10);
            Console.WriteLine("Second");
            subject.SetState(20);
        }

        public class Subject
        {
            public int currentTemp;

            List<Observer> subscribers = new List<Observer>();

            public void SetState(int newState)
            {
                currentTemp = newState;
                NotifyAllObservers();
            }

            public void RegisterNewSubscriber(Observer o)
            {
                subscribers.Add(o);
            }

            public void RemoveSubscriber(Observer o)
            {
                int observerIndex = subscribers.IndexOf(o);
                subscribers.RemoveAt(observerIndex);
            }

            public void NotifyAllObservers()
            {
                foreach (var subsriber in subscribers)
                {
                    subsriber.Update();
                }
            }
        }

        public abstract class Observer
        {
            public Subject subject;
            public abstract void Update();
        }

        public class TempObserverInCelcijus : Observer
        {
            public TempObserverInCelcijus(Subject subject)
            {
                this.subject = subject;
                this.subject.RegisterNewSubscriber(this);
            }

            public override void Update()
            {
                Console.WriteLine("Temperature updated1 " + subject.currentTemp);
            }
        }

        public class TempObserverInFahrenheit : Observer
        {
            public TempObserverInFahrenheit(Subject subject)
            {
                this.subject = subject;
                this.subject.RegisterNewSubscriber(this);
            }

            public override void Update()
            {
                Console.WriteLine("Temperature updated2 " + subject.currentTemp);
            }
        }

    }
}
