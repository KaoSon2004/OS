namespace OS
{
    public class Process
    {
        public int pid;
        public int arrival_time;
        public int burst_time;
        public int remaining_time;
        public int waiting_time;
        public int turnaround_time;
        public int priority;
       
        public int sectionFinish_time;

        public int start_time;
        public int end_time;


        public Process(int pid, int arrival_time, int burst_time, int priority = 0)
        {

            this.pid = pid;
            this.arrival_time = arrival_time;
            this.burst_time = burst_time;
            this.remaining_time = burst_time;
            this.priority = priority;
            
            this.waiting_time = 0;
            this.turnaround_time = 0;
            this.sectionFinish_time = 0;
            this.start_time = 0;
            this.end_time = 0;
        }
    }
}