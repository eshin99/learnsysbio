using UnityEngine;
using System.Collections;
using System;

public class Gaussian {

    bool _hasDeviate;
    double _storedDeviate;
    System.Random _random;

    public Gaussian(System.Random random = null)
    {
        _random = random ?? new System.Random();
    }

    /// <summary>
    /// http://stackoverflow.com/questions/218060/random-gaussian-variables
    /// Obtains normally (Gaussian) distributed random numbers, using the Box-Muller
    /// transformation.  This transformation takes two uniformly distributed deviates
    /// within the unit circle, and transforms them into two independently
    /// distributed normal deviates.
    /// </summary>
    /// <param name="mu">The mean of the distribution.  Default is zero.</param>
    /// <param name="sigma">The standard deviation of the distribution.  Default is one.</param>
    /// <returns></returns>

    public double NextGaussian(double mu, double sigma)
    {
        if (sigma <= 0)
            throw new ArgumentOutOfRangeException("sigma", "Must be greater than zero.");

        if (_hasDeviate)
        {
            _hasDeviate = false;
            return _storedDeviate * sigma + mu;
        }

        double v1, v2, rSquared;
        do
        {
            // two random values between -1.0 and 1.0
            v1 = 2 * _random.NextDouble() - 1;
            v2 = 2 * _random.NextDouble() - 1;
            rSquared = v1 * v1 + v2 * v2;
            // ensure within the unit circle
        } while (rSquared >= 1 || rSquared == 0);

        // calculate polar tranformation for each deviate
        var polar = Math.Sqrt(-2 * Math.Log(rSquared) / rSquared);
        // store first deviate
        _storedDeviate = v2 * polar;
        _hasDeviate = true;
        // return second deviate
        return v1 * polar * sigma + mu;
    }
}
