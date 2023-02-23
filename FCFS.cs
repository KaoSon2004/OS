namespace OS
{
    public class FCFS
    {
        public List<Process> processes = new List<Process>();
        public FCFS(List<Process> processes) {
            this.processes= processes;
        }
    
        public void calFCFS() {
            this.processes[0].waiting_time = 0; 
            for(int i = 1; i < this.processes.Count; i++) {
                int sum = 0;
                for(int j = 0; j < i; j++) {
                    sum += this.processes[j].burst_time;
                }
                this.processes[i].waiting_time = sum - this.processes[i].arrival_time;

            }
            for(int i = 0; i < this.processes.Count; i++) {
                this.processes[i].turnaround_time = this.processes[i].waiting_time + this.processes[i].burst_time;
            }
            double total_waiting_time = 0;
            double total_turnaround_time = 0;
            foreach(var process in processes) {
                total_waiting_time += process.waiting_time;
                total_turnaround_time += process.turnaround_time;
            }
            Console.WriteLine("PID\tArrivalTime\tBurst Time\tWaiting Time\tTurnaround Time");
            foreach(var process in processes) {
                Console.WriteLine("{0}\t{1}\t\t{2}\t\t{3}\t\t{4}",process.pid, process.arrival_time, process.burst_time, process.waiting_time, process.turnaround_time);
           
            }
            Console.WriteLine("Average Waiting Time: {0}", total_waiting_time / processes.Count );
            Console.WriteLine("Average Turnaround Time: {0}", total_turnaround_time / processes.Count);
        }
        

    }
}