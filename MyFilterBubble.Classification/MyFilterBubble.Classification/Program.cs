using MyFilterBubble.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilterBubble.Classification
{
    class Program
    {
        static void Main(string[] args)
        {
            Initializer.InitializeAutoMapper();

            // train system with user classification
            var trainer = new Trainer();
            trainer.Execute();

            // classify new feeditems
            var classifier = new Classifier();
            classifier.Execute();
                        

        }
    }
}
