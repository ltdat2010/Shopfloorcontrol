namespace Production.Class._GEN
{
    internal class Point
    {
        private double _dblX;
        private double _dblY;

        public double X_Coord
        {
            get { return _dblX; }
            set { _dblX = value; }
        }

        public double Y_Coord
        {
            get { return _dblY; }
            set { _dblY = value; }
        }

        public Point(double X_Coordinate, double Y_Coordinate)
        {
            _dblX = X_Coordinate;
            _dblY = Y_Coordinate;
        }
    }
}