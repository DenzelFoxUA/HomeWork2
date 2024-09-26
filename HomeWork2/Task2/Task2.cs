using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2.Task2
{
    public static class Task2
    {
        public static void Run()
        {
            List<Musical_Instrument> _instruments = new List<Musical_Instrument>();

            //ініціалізація сутностей білдером (паттерн білдер реалізований в абстрактному, базовому класі)
            Cello cello = CreateMusicalInstrument<Cello>("Cello",
                                                         "Cello sound",
                                                         "Description of a Cello",
                                                         "Some text of Cello history here");

            Violin violin = CreateMusicalInstrument<Violin>("Violin",
                                                            "Sound of Violin",
                                                            "Muiscal instrument description",
                                                            "History of Violin");

            //тест сутностей, якщо створити муз інструмент без ініціалізаціїї полів
            Ukulele ukulele = new Ukulele();
            Trombone trombone = new Trombone();

            _instruments.Add(violin);
            _instruments.Add(cello);
            _instruments.Add(ukulele);
            _instruments.Add(trombone);

            MakeASoundOfAll(_instruments);

            ShowAllNames(_instruments);

            ShowAllDescriptions(_instruments);

            ShowAllHistory(_instruments);

            //створення нових об"єктів, тільки ініціалізація через білдер
            Ukulele ukulele2 = CreateMusicalInstrument<Ukulele>("Ukulele",
                                                                "Sound of Ukulele",
                                                                "Ukulele instrument description",
                                                                "History of Ukulele");

            Trombone trombone2 = CreateMusicalInstrument<Trombone>("Trombone",
                                                                "Sound of Trombone",
                                                                "Trombone instrument description",
                                                                "History of Trombone");

            _instruments.RemoveAll(x=>x.ShowName() == "Default");

            _instruments.Add(trombone2);
            _instruments.Add(ukulele2);

            Console.Clear();

            MakeASoundOfAll(_instruments);

            ShowAllNames(_instruments);

            ShowAllDescriptions(_instruments);

            ShowAllHistory(_instruments);

        }

        private static T CreateMusicalInstrument<T>(string name,
                                                    string sound,
                                                    string description,
                                                    string history) where T : Musical_Instrument, new()
        {
            
            var builder = new Musical_Instrument.Instrument_Builder<T>();

            var instrument = builder.SetName(name)
                                    .SetSound(sound)
                                    .SetDescription(description)
                                    .SetHistory(history)
                                    .Build();

            return instrument;
        }
        
        private static void Print(List<Musical_Instrument> _instruments)
        {
            foreach (var instrument in _instruments)
            {
                Console.WriteLine(instrument);
            }
            Console.ReadLine();
            Console.Clear();
        }

        private static void MakeASoundOfAll(List<Musical_Instrument> _instruments)
        {
            foreach (var instrument in _instruments)
            {
                instrument.MakeASound();
            }
            Console.ReadLine();
            Console.Clear();
        }

        private static void ShowAllNames(List<Musical_Instrument> _instruments)
        {
            foreach (var instrument in _instruments)
            {
                instrument.ShowName();
            }
            Console.ReadLine();
            Console.Clear();
        }
        private static void ShowAllHistory(List<Musical_Instrument> _instruments)
        {
            foreach (var instrument in _instruments)
            {
                instrument.ShowHistory();
            }
            Console.ReadLine();
            Console.Clear();
        }

        private static void ShowAllDescriptions(List<Musical_Instrument> _instruments)
        {
            foreach (var instrument in _instruments)
            {
                instrument.ShowDescription();
            }
            Console.ReadLine();
            Console.Clear();
        }

    }
}
