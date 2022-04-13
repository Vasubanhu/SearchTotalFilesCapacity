namespace SearchTotalFilesCapacity
{
    internal static class Converter
    {
        private enum InformationUnits
        {
            Kb = 10,
            Mb = 20,
            Gb = 30,
            Tb = 40
        }

        private const sbyte Value = 2;

        internal static string BytesConvertTo(this string bytes)
        {
            var cbytes = double.Parse(bytes);

            if (cbytes >= Math.Pow(Value, (double) InformationUnits.Kb))
                return $"{cbytes / Math.Pow(Value, (double) InformationUnits.Kb):F} KB";
            if (cbytes >= Math.Pow(Value, (double)InformationUnits.Mb))
                return $"{cbytes / Math.Pow(Value, (double)InformationUnits.Mb):F} MB";
            if (cbytes >= Math.Pow(Value, (double)InformationUnits.Gb))
                return $"{cbytes / Math.Pow(Value, (double)InformationUnits.Gb):F} GB";
            if (cbytes >= Math.Pow(Value, (double)InformationUnits.Tb))
                return $"{cbytes / Math.Pow(Value, (double)InformationUnits.Tb):F} TB";

            return $"{bytes} bytes";
        }
    }
}
