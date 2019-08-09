using DevExpress.XtraEditors;
using System.Collections.Generic;


namespace Production.Class._GEN
{
    class Equation_Fomular
    {
        MYCOTOXIN_RESULT_StandardCurve OBj = new MYCOTOXIN_RESULT_StandardCurve();
        //public static void calcValues(ArrayList alPoints)
        public MYCOTOXIN_RESULT_StandardCurve calcValues(string acronym,List<double> alPoints)
        {
            //double sumOfX = 0;
            //double sumOfY = 0;
            //double sumOfXSq = 0;
            //double sumOfYSq = 0;
            //double ssX = 0;
            //double ssY = 0;
            //double sumCodeviates = 0;
            //double sCo = 0;

            //double xy = 0;
            //double x2 = 0;
            //double y2 = 0;
            int n = alPoints.Count / 2; ;
            double Sx = 0;
            double Sy = 0;
            double Sxy= 0;
            double Sx2 = 0;
            double Sy2 = 0;
            double SxSx = 0;
            double SySy = 0;
            double a_SLOPE;
            double b_INTERCEPT;
            double r;
            double R_SQUARE;


            for (int ctr = 0; ctr < alPoints.Count; ctr=ctr + 2)
            {
                //int i = 0;
                Point objPoint = new Point(alPoints[ctr], alPoints[ctr + 1]);

                //objPoint.X_Coord= alPoints[ctr];
                //objPoint.Y_Coord= alPoints[ctr+1];

                double x = double.Parse(objPoint.X_Coord.ToString());
                double y = double.Parse(objPoint.Y_Coord.ToString());

                //XtraMessageBox.Show("x :" + x);
                //XtraMessageBox.Show("y :" + y);

                //sumCodeviates += (x * y);
                //sumOfX += x;
                //sumOfY += y;
                //sumOfXSq = sumOfXSq + (x * x);
                //sumOfYSq = sumOfYSq + (y * y);           
                                            
                Sx = Sx + x;

                Sy = Sy + y;

                Sxy = Sxy + (x * y);

                Sx2 = Sx2 + (x * x);

                Sy2 = Sy2 + (y * y);

                

                //xy.SetValue(x * y, i);







            }

            SxSx = Sx * Sx;

            SySy = Sy * Sy ;

            a_SLOPE = (n * Sxy - Sx * Sy) / (n * Sx2 - SxSx);

            b_INTERCEPT = (Sy - a_SLOPE * Sx) / n;

            r = ((n * Sxy) - (Sx * Sy)) / System.Math.Sqrt((n * Sx2 - SxSx)*(n * Sy2 - Sy * Sy));

            R_SQUARE = r * r;

            //sumOfXSq = Math.Round(sumOfXSq, 2);
            //sumOfYSq = Math.Round(sumOfYSq, 2);

            //ssX = sumOfXSq - ((sumOfX * sumOfX)/ alPoints.Count);

            //ssY = sumOfYSq - ((sumOfY * sumOfY)/ alPoints.Count);

            //double RNumerator = (alPoints.Count * sumCodeviates) - (sumOfX * sumOfY) ;

            //double RDenom = (alPoints.Count * sumOfXSq - (Math.Pow(sumOfX, 2)) ) *(alPoints.Count * sumOfYSq - (Math.Pow(sumOfY, 2)) ) ;

            //sCo = sumCodeviates - ((sumOfX * sumOfY) / alPoints.Count);

            //double dblSlope = sCo / ssX;
            //double meanX = sumOfX / alPoints.Count;
            //double meanY = sumOfY / alPoints.Count;
            //double dblYintercept = meanY - (dblSlope * meanX);
            //double dblR = RNumerator / Math.Sqrt(RDenom);

            ////double dblSlope = dblSlope;
            ////Console.WriteLine( “R - Squared: { 0}”,  Math.Pow(dblR, 2) ) ;
            ////Console.WriteLine( “Y - Intercept: { 0}”,  dblYIntercept ) ;
            ////Console.WriteLine( “Slope: { 0}”,  dblSlope ) ;
            ////Console.ReadLine();
            //XtraMessageBox.Show("Sx :" + Sx.ToString());
            //XtraMessageBox.Show("Sy :" + Sy.ToString());
            //XtraMessageBox.Show("Sxy :" + Sxy.ToString());
            //XtraMessageBox.Show("Sx2 :" + Sx2.ToString());
            //XtraMessageBox.Show("Sy2 :" + Sy2.ToString());
            //XtraMessageBox.Show("SxSx :" + SxSx.ToString());
            //XtraMessageBox.Show("SySy :" + SySy.ToString());
            //XtraMessageBox.Show("a_Slope :" + a_SLOPE.ToString());
            //XtraMessageBox.Show("b_Intercept :" + b_INTERCEPT.ToString());
            //XtraMessageBox.Show("R_Squared :" + R_SQUARE.ToString());

            
            OBj.Acronym = acronym;
            OBj.a_SLOPE = a_SLOPE;
            OBj.b_INTERCEPT = b_INTERCEPT;
            OBj.R_SQUARE = R_SQUARE;

            //return "y = " + Math.Pow(dblR, 2).ToString() + "x" + " " + dblYintercept.ToString();
            return OBj;
        }
    }
}
