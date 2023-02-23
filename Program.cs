namespace OS {
    class OS {
        static void Main(string[] args) {
            List<Process> processes = new List<Process>();
            processes.Add(new Process(1,0,5));
            processes.Add(new Process(2,1,3));
            processes.Add(new Process(3,2, 8));
            processes.Add(new Process(4,3,6));
            FCFS fCFS = new FCFS(processes);
            fCFS.calFCFS();

            List<Process> processes1 = new List<Process>();
            processes1.Add(new Process(1, 0,53));
            processes1.Add(new Process(2, 0,17));
            processes1.Add(new Process(3, 0,68));
            processes1.Add(new Process(4, 0, 24));
            RoundRobin roundRobin = new RoundRobin(processes1);
            roundRobin.calRoundRobin();


            List<Process> processes2 = new List<Process>();
            processes2.Add(new Process(1,0,7));
            processes2.Add(new Process(2,2,4));
            processes2.Add(new Process(3,4,1));
            processes2.Add(new Process(4,5,4));
            SJF sJF = new SJF(processes2);
            sJF.ScheduleSJF();
            List<Process> processes3 = new List<Process>();
            processes3.Add(new Process(1,0,11,2));
            processes3.Add(new Process(2,5,28,0));
            processes3.Add(new Process(3,12,2,3));
            processes3.Add(new Process(4,2,10,1));
            processes3.Add(new Process(5,9,16,4));
            Priority priority = new Priority(processes3);
            priority.SchedulePriority();

            List<Process> processes4 = new List<Process>();
            processes3.Add(new Process(1, 0, 8));
            processes3.Add(new Process(2,1 ,4));
            processes3.Add(new Process(3, 2,2));
            processes3.Add(new Process(4,3,1));
            processes3.Add(new Process(5,4,3));
            processes3.Add(new Process(6,5,2));

        }

    }
}