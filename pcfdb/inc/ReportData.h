#ifndef REPORTDATA_H_
#define REPORTDATA_H_

#include <vector>
#include "SelectionParameters.h"

class ReportData {
public:
    enum {
        PIE, MONTHLY
    };

    enum {
        INCOME, EXPENSES
    };

    ReportData(int chart, int direction, const SelectionParameters& parameters);
    virtual ~ReportData();

    int getChartType() const;
    int getFlowDirection() const;
    const SelectionParameters& getParameters() const;
    const std::vector<double>& getData() const;

    void acquire();

private:
    int chart_;
    int direction_;
    SelectionParameters parameters_;
    std::vector<double> data_;

    void fetchPieData(const std::vector<int>& sel);
    void fetchMonthlyData(const std::vector<int>& sel);
};

inline int ReportData::getChartType() const
{
    return chart_;
}

inline int ReportData::getFlowDirection() const
{
    return direction_;
}

inline const SelectionParameters& ReportData::getParameters() const
{
    return parameters_;
}

inline const std::vector<double>& ReportData::getData() const
{
    return data_;
}

#endif /* REPORTDATA_H_ */
