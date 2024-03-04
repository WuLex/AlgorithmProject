namespace AlgorithmSpace.Logic
{
    public class RedPacketGenerator
    {
        private readonly Random random = new Random();

        public decimal[] GenerateRedPackets(decimal totalAmount, int count)
        {
            decimal[] redPackets = new decimal[count];
            decimal average = totalAmount / count;
            decimal variance = 0.05m;

            for (int i = 0; i < count; i++)
            {
                decimal amount = SampleNormalDistribution(average, variance);
                redPackets[i] = decimal.Round(amount, 2);
            }

            return redPackets;
        }

        private decimal SampleNormalDistribution(decimal mean, decimal variance)
        {
            decimal stdDev = (decimal)Math.Sqrt((double)variance);
            decimal u1 = (decimal)random.NextDouble();
            decimal u2 = (decimal)random.NextDouble();
            decimal randStdNormal = (decimal)Math.Sqrt(-2.0 * Math.Log((double)u1)) *
                                    (decimal)Math.Sin(2.0 * Math.PI * (double)u2);
            decimal randNormal = mean + stdDev * randStdNormal;
            return randNormal;
        }
    }
}