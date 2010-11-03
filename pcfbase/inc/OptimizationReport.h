#ifndef OPTIMIZATIONREPORT_H_
#define OPTIMIZATIONREPORT_H_

#include <vector>

class OptimizationReport {
public:
    OptimizationReport();
    ~OptimizationReport();

    bool isRemoveUnusedItems() const;
    size_t getUnusedItemsCount() const;
    int getUnusedItemId(size_t idx) const;

    void setRemoveUnusedItems(bool);
    void addUnusedItemId(int id);

private:
    std::vector<int> unusedItems_;
    bool removeUnusedItems_;
};

inline bool OptimizationReport::isRemoveUnusedItems() const
{
    return removeUnusedItems_;
}

inline size_t OptimizationReport::getUnusedItemsCount() const
{
    return unusedItems_.size();
}

inline int OptimizationReport::getUnusedItemId(size_t idx) const
{
    return unusedItems_[idx];
}

#endif /* OPTIMIZATIONREPORT_H_ */
