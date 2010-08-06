#ifndef SELECTIONPARAMETERS_H
#define SELECTIONPARAMETERS_H

namespace adb {

class SelectionParameters {
public:
    SelectionParameters();

    int getItemId() const;
    bool isLastTransactionOnly() const;

    void setItemId(int);
    void setLastTransactionOnly(bool);

private:
    int itemId_;
    bool lastTrnsactionOnly_;
};

inline int SelectionParameters::getItemId() const
{
    return itemId_;
}

inline bool SelectionParameters::isLastTransactionOnly() const
{
    return lastTrnsactionOnly_;
}

} // namespace adb

#endif // SELECTIONPARAMETERS_H
