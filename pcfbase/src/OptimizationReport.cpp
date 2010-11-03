#include <OptimizationReport.h>

OptimizationReport::OptimizationReport() :
    removeUnusedItems_(false)
{
}

OptimizationReport::~OptimizationReport()
{
}

void OptimizationReport::setRemoveUnusedItems(bool val)
{
    removeUnusedItems_ = val;
}

void OptimizationReport::addUnusedItemId(int id)
{
    unusedItems_.push_back(id);
    removeUnusedItems_ = true;
}
