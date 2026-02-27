using FiniteStateMachinesToPetriNets.FiniteStateMachines;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmark
{
    internal class BenchmarkHelper
    {
        private static string Triggers = "abcdefghijklmnop";

        public static StateMachine CreateRandomStateMachine(int size)
        {
            var random = new Random(42);
            var stateMachine = new StateMachine { Id = "SyntheticStateMachine" };
            var nStates = (size - 1) / 3;
            for (int i = 0; i < nStates; i++)
            {
                stateMachine.States.Add(new State { Name = $"S{i:000000}" });
            }
            var nTransitions = size - nStates - 1;
            var index = 0;
            for (int i = 0; i < nTransitions; i++)
            {
                if (random.NextDouble() < 0.3334)
                {
                    index++;
                }
                var source = stateMachine.States[index];
                var dest = stateMachine.States[random.Next(nStates)];

                stateMachine.Transitions.Add(new Transition
                {
                    StartState = source,
                    EndState = dest,
                    Input = Triggers[i % Triggers.Length].ToString(),
                });
            }

            stateMachine.States[random.Next(nStates)].IsInitial = true;

            for (int i = 0; i < 20; i++)
            {
                var j = random.Next(nStates);
                while (stateMachine.States[j].IsFinal)
                {
                    j = random.Next(nStates);
                }
                stateMachine.States[random.Next(nStates)].IsFinal = true;
            }

            return stateMachine;
        }
    }
}
