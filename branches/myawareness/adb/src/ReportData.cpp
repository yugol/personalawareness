#include <ReportData.h>

namespace adb {

    ReportData::ReportData(int chart, int direction, const SelectionParameters& parameters) :
        chart_(chart), direction_(direction), parameters_(parameters)
    {
    }

    ReportData::~ReportData()
    {
    }

    void ReportData::acquire()
    {

    }

} // namespac eadb
