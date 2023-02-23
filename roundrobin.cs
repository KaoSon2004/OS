using System;
using System.Collections.Generic;
namespace OS {

    class RoundRobin
    {
        public  List <Process> processes = new List<Process>();
        public int num_process;
        public double total_waiting_time = 0;
        public double total_turnaround_time = 0;
        public RoundRobin(List<Process> processes) {
            this.processes = processes;
            num_process = processes.Count;
        }
        public  void calRoundRobin()
        {


            int time_quantum = 20;

            this.processes.Sort((x, y) => x.arrival_time.CompareTo(y.arrival_time));

            int current_time = 0;

            Console.WriteLine("PID\tArrival Time\tBurst Time\tWaiting Time\tTurnaround Time");

            while (this.processes.Count > 0)
            {
                Process current_process = this.processes[0];
                this.processes.RemoveAt(0);

                int time_run = Math.Min(time_quantum, current_process.remaining_time);
                current_process.remaining_time -= time_run;
                
                current_time += time_run;
                current_process.waiting_time += (current_time - time_run  - current_process.sectionFinish_time);
                current_process.sectionFinish_time = current_time;
                if (current_process.remaining_time > 0)
                {
                    this.processes.Add(current_process);
                }
                else
                {
                    current_process.turnaround_time = current_process.waiting_time + current_process.burst_time;
                    Console.WriteLine("{0}\t{1}\t\t{2}\t\t{3}\t\t{4}", current_process.pid, current_process.arrival_time, current_process.burst_time, current_process.waiting_time, current_process.turnaround_time);
                    total_waiting_time += current_process.waiting_time;
                    total_turnaround_time += current_process.turnaround_time;
                
                }
            }

            double average_waiting_time = this.total_waiting_time / num_process;
            double average_turnaround_time = this.total_turnaround_time / num_process;
            Console.WriteLine("Average waiting time: {0}", average_waiting_time);
            Console.WriteLine("Average turnaround time: {0}", average_turnaround_time);
        }
    }
}