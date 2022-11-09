using Google.OrTools.LinearSolver;

namespace WebApp_LB3.Models
{
    public class ResultViewModel
    {
        public DataViewModel dataViewModel;

        public ResultViewModel(DataViewModel dataViewModel)
        {
            this.dataViewModel = dataViewModel;
            SolverRun();
        }


        public void SolverRun()
        {
            Solver solver = Solver.CreateSolver("GLOP");

            Variable x1 = solver.MakeNumVar(0.0, double.PositiveInfinity, "x1");
            Variable x2 = solver.MakeNumVar(0.0, double.PositiveInfinity, "x2");
            Variable x3 = solver.MakeNumVar(0.0, double.PositiveInfinity, "x3");
            Variable x4 = solver.MakeNumVar(0.0, double.PositiveInfinity, "x4");
            Variable x5 = solver.MakeNumVar(0.0, double.PositiveInfinity, "x5");
            Variable x6 = solver.MakeNumVar(0.0, double.PositiveInfinity, "x6");

            solver.Add(
                (x1 * dataViewModel.A1_ColvoZag_1 + x2 * dataViewModel.A1_ColvoZag_2 +
                x3 * dataViewModel.A1_ColvoZag_3 + x4 * dataViewModel.A1_ColvoZag_4 +
                x5 * dataViewModel.A1_ColvoZag_5 + x6 * dataViewModel.A1_ColvoZag_6) ==
                (dataViewModel.Zag_R * dataViewModel.A1_ColvoNaOd)
                );

            solver.Add(
                (x1 * dataViewModel.A2_ColvoZag_1 + x2 * dataViewModel.A2_ColvoZag_2 +
                x3 * dataViewModel.A2_ColvoZag_3 + x4 * dataViewModel.A2_ColvoZag_4 +
                x5 * dataViewModel.A2_ColvoZag_5 + x6 * dataViewModel.A2_ColvoZag_6) ==
                (dataViewModel.Zag_R * dataViewModel.A2_ColvoNaOd)
                );

            solver.Add(
                (x1 * dataViewModel.A3_ColvoZag_1 + x2 * dataViewModel.A3_ColvoZag_2 +
                x3 * dataViewModel.A3_ColvoZag_3 + x4 * dataViewModel.A3_ColvoZag_4 +
                x5 * dataViewModel.A3_ColvoZag_5 + x6 * dataViewModel.A3_ColvoZag_6) ==
                (dataViewModel.Zag_R * dataViewModel.A3_ColvoNaOd)
                );

            solver.Add(
                (x1 * dataViewModel.A4_ColvoZag_1 + x2 * dataViewModel.A4_ColvoZag_2 +
                x3 * dataViewModel.A4_ColvoZag_3 + x4 * dataViewModel.A4_ColvoZag_4 +
                x5 * dataViewModel.A4_ColvoZag_5 + x6 * dataViewModel.A4_ColvoZag_6) ==
                (dataViewModel.Zag_R * dataViewModel.A4_ColvoNaOd)
                );

            solver.Add(
                (x1 * dataViewModel.A5_ColvoZag_1 + x2 * dataViewModel.A5_ColvoZag_2 +
                x3 * dataViewModel.A5_ColvoZag_3 + x4 * dataViewModel.A5_ColvoZag_4 +
                x5 * dataViewModel.A5_ColvoZag_5 + x6 * dataViewModel.A5_ColvoZag_6) ==
                (dataViewModel.Zag_R * dataViewModel.A5_ColvoNaOd)
                );

            solver.Minimize(Othod1 * x1 + Othod2 * x2 + Othod3 * x3 + Othod4 * x4 + Othod5 * x5 + Othod6 * x6);

            Solver.ResultStatus resultStatus = solver.Solve();

            Cel = Math.Round(solver.Objective().Value(), 0);

            X1 = Math.Round(x1.SolutionValue(), 0);
            X2 = Math.Round(x2.SolutionValue(), 0);
            X3 = Math.Round(x3.SolutionValue(), 0);
            X4 = Math.Round(x4.SolutionValue(), 0);
            X5 = Math.Round(x5.SolutionValue(), 0);
            X6 = Math.Round(x6.SolutionValue(), 0);
        }



        public double X1 { get; set; }
        public double X2 { get; set; }
        public double X3 { get; set; }
        public double X4 { get; set; }
        public double X5 { get; set; }
        public double X6 { get; set; }

        #region Отходы
        public double Othod1
        {
            get => dataViewModel.Zag_F - (
                dataViewModel.A1_PloPovZag * dataViewModel.A1_ColvoZag_1 +
                dataViewModel.A2_PloPovZag * dataViewModel.A2_ColvoZag_1 +
                dataViewModel.A3_PloPovZag * dataViewModel.A3_ColvoZag_1 +
                dataViewModel.A4_PloPovZag * dataViewModel.A4_ColvoZag_1 +
                dataViewModel.A5_PloPovZag * dataViewModel.A5_ColvoZag_1);
        }
        public double Othod2
        {
            get => dataViewModel.Zag_F - (
                dataViewModel.A1_PloPovZag * dataViewModel.A1_ColvoZag_2 +
                dataViewModel.A2_PloPovZag * dataViewModel.A2_ColvoZag_2 +
                dataViewModel.A3_PloPovZag * dataViewModel.A3_ColvoZag_2 +
                dataViewModel.A4_PloPovZag * dataViewModel.A4_ColvoZag_2 +
                dataViewModel.A5_PloPovZag * dataViewModel.A5_ColvoZag_2);
        }
        public double Othod3
        {
            get => dataViewModel.Zag_F - (
                dataViewModel.A1_PloPovZag * dataViewModel.A1_ColvoZag_3 +
                dataViewModel.A2_PloPovZag * dataViewModel.A2_ColvoZag_3 +
                dataViewModel.A3_PloPovZag * dataViewModel.A3_ColvoZag_3 +
                dataViewModel.A4_PloPovZag * dataViewModel.A4_ColvoZag_3 +
                dataViewModel.A5_PloPovZag * dataViewModel.A5_ColvoZag_3);
        }
        public double Othod4
        {
            get => dataViewModel.Zag_F - (
                dataViewModel.A1_PloPovZag * dataViewModel.A1_ColvoZag_4 +
                dataViewModel.A2_PloPovZag * dataViewModel.A2_ColvoZag_4 +
                dataViewModel.A3_PloPovZag * dataViewModel.A3_ColvoZag_4 +
                dataViewModel.A4_PloPovZag * dataViewModel.A4_ColvoZag_4 +
                dataViewModel.A5_PloPovZag * dataViewModel.A5_ColvoZag_4);
        }
        public double Othod5
        {
            get => dataViewModel.Zag_F - (
                dataViewModel.A1_PloPovZag * dataViewModel.A1_ColvoZag_5 +
                dataViewModel.A2_PloPovZag * dataViewModel.A2_ColvoZag_5 +
                dataViewModel.A3_PloPovZag * dataViewModel.A3_ColvoZag_5 +
                dataViewModel.A4_PloPovZag * dataViewModel.A4_ColvoZag_5 +
                dataViewModel.A5_PloPovZag * dataViewModel.A5_ColvoZag_5);
        }
        public double Othod6
        {
            get => dataViewModel.Zag_F - (
                dataViewModel.A1_PloPovZag * dataViewModel.A1_ColvoZag_6 +
                dataViewModel.A2_PloPovZag * dataViewModel.A2_ColvoZag_6 +
                dataViewModel.A3_PloPovZag * dataViewModel.A3_ColvoZag_6 +
                dataViewModel.A4_PloPovZag * dataViewModel.A4_ColvoZag_6 +
                dataViewModel.A5_PloPovZag * dataViewModel.A5_ColvoZag_6);
        }

        public double Cel { get; set; }

        #endregion

    }
}
