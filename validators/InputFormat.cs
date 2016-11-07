namespace validators
{
    public struct InputFormat
    {
        public string Name { get; set; }
        public string Pattern { get; set; }
        public string Value { get; set; }

        public InputFormat(string name, string pattern, string value)
        {
            Name = name;
            Pattern = pattern;
            Value = value;
        }
    }
}
