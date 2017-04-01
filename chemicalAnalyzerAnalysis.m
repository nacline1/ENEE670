function chemicalAnalyzerAnalysis()
    maxConcentration = 12000; % PPM
    variance = 0.005; % Percentage
    numDataPoints = 1000000;
    for numAnalyzers = 1:16
        measuredConcentration = normrnd(maxConcentration, (variance * maxConcentration) ^ (1/sqrt(numAnalyzers)), numDataPoints, 1);
        dfittool(measuredConcentration)
    end
end