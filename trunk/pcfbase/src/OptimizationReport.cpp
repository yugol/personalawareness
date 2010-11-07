#include <OptimizationReport.h>

OptimizationReport::OptimizationReport() :
    removeUnusedItems_(false)
{
}

OptimizationReport::~OptimizationReport()
{
}

void OptimizationReport::setRemoveUnusedItems(bool value)
{
    removeUnusedItems_ = value;
}

void OptimizationReport::addUnusedItemId(int id)
{
    unusedItems_.push_back(id);
    removeUnusedItems_ = true;
}
