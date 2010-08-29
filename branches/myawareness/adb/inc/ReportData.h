#ifndef REPORTDATA_H_
#define REPORTDATA_H_

#include "SelectionParameters.h"

namespace adb {

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

        void acquire();

    private:
        int chart_;
        int direction_;
        SelectionParameters parameters_;
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

} // namespace adb

#endif /* REPORTDATA_H_ */
