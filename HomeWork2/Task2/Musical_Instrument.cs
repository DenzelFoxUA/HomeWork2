using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeWork2.Task2
{
    public abstract class Musical_Instrument
    {
        protected abstract string Sound { get; set; }
        protected abstract string Name { get; set; }

        protected abstract string Description { get; set; }

        protected abstract string History { get; set; }

        protected Musical_Instrument() 
        {
            Sound = "Default sound";
            Name = "Default";
            Description = "Default description";
            History = "Default history";
        }

        public class Instrument_Builder<T> where T: Musical_Instrument, new()
        {
            private T _musical_instrument = new T();

            public Instrument_Builder<T> SetSound(string sound) 
            { 
                _musical_instrument.Sound = sound;
                return this;
            }

            public Instrument_Builder<T> SetName(string name) 
            { 
                _musical_instrument.Name = name;
                return this; 
            }

            public Instrument_Builder<T> SetDescription(string description)
            {
                _musical_instrument.Description = description;
                return this;
            }

            public Instrument_Builder<T> SetHistory(string history)
            {
                _musical_instrument.History = history;
                return this;
            }

            public T Build()
            {
                return _musical_instrument;
            }
        }

        public virtual string MakeASound()
        {
            Console.WriteLine($"{Name} sounds like {Sound}");
            return Sound;
        }

        public virtual string ShowHistory()
        {
            Console.WriteLine($"{Name}: {History}");
            return History;
        }

        public virtual string ShowDescription()
        {
            Console.WriteLine($"{Name}: {Description}");
            return Description;
        }

        public virtual string ShowName()
        {
            Console.WriteLine(Name);
            return Name;
        }

        public override string ToString()
        {
            return $"Sound: {Sound}\n" +
                $"Name: {Name}\n" +
                $"Description:\n{Description}\n" +
                $"History:\n{History}\n";
        }
    }
}
