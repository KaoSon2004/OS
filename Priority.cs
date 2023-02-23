using System;

namespace OS {
using System;
using System.Collections.Generic;

public class Priority
{
    public List<Process> processes;
    public Priority(List<Process> processes) {
        this.processes = processes;
    }
    public  void SchedulePriority()
    {
            PriorityQueue<Process> queue = new PriorityQueue<Process>();
            List<Process> ans = new List<Process>();

            int currentTime = this.processes[0].arrival_time;

            while (queue.Count > 0 || this.processes.Count > 0)
            {
                while (this.processes.Count > 0 && this.processes[0].arrival_time <= currentTime)
                {
                    queue.EnqueueAsc(this.processes[0], this.processes[0].priority);
                    this.processes.RemoveAt(0);
                }

                if (queue.Count > 0)
                {
                    Process process = queue.Dequeue();

                    process.start_time = currentTime;
                    process.end_time = currentTime + process.burst_time;

                    process.turnaround_time = process.end_time - process.arrival_time;
                    process.waiting_time = process.start_time - process.arrival_time;

                    ans.Add(process);
                    currentTime = process.end_time;
                }
                else
                {
                    currentTime++;
                }
            }
            Console.WriteLine("PID\tArrival Time\tBurst Time\tWaiting Time\tTurnaround Time");
            double total_waiting_time = 0;
            double total_turnaround_time = 0;
            foreach(var current_process in ans) {
                Console.WriteLine("{0}\t{1}\t\t{2}\t\t{3}\t\t{4}", current_process.pid, current_process.arrival_time, current_process.burst_time, current_process.waiting_time, current_process.turnaround_time);
                total_turnaround_time += current_process.turnaround_time;
                total_waiting_time += current_process.waiting_time;
            
            }
            Console.WriteLine("Average waiting time: {0}", total_waiting_time/ans.Count);
            Console.WriteLine("Average turnaround time: {0}", total_turnaround_time/ ans.Count);
            
        

    }

}

}