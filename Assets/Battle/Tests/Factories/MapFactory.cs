namespace Battle.Tests.Factories
{
    public class MapBuilder
    {
        private int _width = 10;
        private int _height = 10;

        public MapBuilder WithWidth(int width)
        {
            _width = width;
            return this;
        }
        
        public MapBuilder WithHeight(int height)
        {
            _height = height;
            return this;
        }

        public Map Build()
        {
            return new Map(_width, _height);
        }
    }
    
    public static class MapFactory
    {
        public static MapBuilder AMap => new MapBuilder();
    }
}
