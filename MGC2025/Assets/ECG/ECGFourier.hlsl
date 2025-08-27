// ECGFourierNode.hlsl
// Unity Shader Graph Custom Function Node for ECG approximation
// Inputs: x (position), bpm, order, speed
// Output: y in [-1,1]

#ifndef PI
#define PI 3.14159265359
#endif

// Fourier approximation of periodic Gaussian
float PeriodicGaussian(float x, float mu, float sigma, int N)
{
    float sum = 1.0; // k=0 term
    [loop]
    for (int k = 1; k <= 128; k++) // Limit terms
    {
        if (k > N) break;
        float fk = (float)k;
        float a  = exp(-2.0 * PI * PI * sigma * sigma * fk * fk);
        sum += 2.0 * a * cos(2.0 * PI * fk * (x - mu));
    }
    return sqrt(2.0 * PI) * sigma * sum;
}

// Main ECG function
void ECGFourierNode_float(float x, float bpm, int order, float speed, out float y)
{
    // Phase: how far in the beat we are [0,1)
    float hz = bpm / 60.0;
    float phase = frac((x * speed) * hz);

    // ECG component parameters
    float A_p = 0.12,  mu_p = 0.18,  s_p = 0.025;
    float A_q = -0.22, mu_q = 0.285, s_q = 0.010;
    float A_r =  1.20, mu_r = 0.300, s_r = 0.008;
    float A_s = -0.35, mu_s = 0.315, s_s = 0.010;
    float A_t =  0.35, mu_t = 0.54,  s_t = 0.05;
    float A_u =  0.06, mu_u = 0.82,  s_u = 0.035;

    // Sum contributions
    float val = 0.0;
    val += A_p * PeriodicGaussian(phase, mu_p, s_p, order);
    val += A_q * PeriodicGaussian(phase, mu_q, s_q, order);
    val += A_r * PeriodicGaussian(phase, mu_r, s_r, order);
    val += A_s * PeriodicGaussian(phase, mu_s, s_s, order);
    val += A_t * PeriodicGaussian(phase, mu_t, s_t, order);
    val += A_u * PeriodicGaussian(phase, mu_u, s_u, order);

    // Output normalized ECG
    y = val;
}
