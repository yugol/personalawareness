#include <algorithm>
#include <Exception.h>
#include <Random.h>
#include <Dictionary.h>
#include <WordSelection.h>

using namespace std;

static Random randomizer;

static bool compareWordPointers(const std::wstring* s1, const std::wstring* s2)
{
	return ((*s1) < (*s2));
}

WordSelection::WordSelection(const Dictionary& dictionary) :
	dictionary_(&dictionary)
{
}

WordSelection::~WordSelection()
{
}

const std::wstring& WordSelection::getRandomWord() const
{
	if (words_.size() == 0) {
		THROW("selection is empty");
	}
	return *(words_[randomizer.nextInt(words_.size())]);
}

void WordSelection::sort()
{
	std::sort(words_.begin(), words_.end(), compareWordPointers);
}

wostream& WordSelection::write(wostream& out) const
{
	out << endl;
	for (size_t i = 0; i < words_.size(); ++i) {
		out << (*(words_[i])) << endl;
	}
	return out;
}

void WordSelection::selectAll()
{
	words_.clear();
	Dictionary::const_iterator it = dictionary_->begin();
	for (; it != dictionary_->end(); ++it) {
		words_.push_back(&(it->first));
	}
}

void WordSelection::selectByPattern(const WordSelector& selector)
{
	words_.clear();
	Dictionary::const_iterator it = dictionary_->begin();
	for (; it != dictionary_->end(); ++it) {
		const wstring& word = it->first;
		if (selector.isPatternMatch(word)) {
			words_.push_back(&word);
		}
	}
}

void WordSelection::selectByHistogram(const WordSelector& selector)
{
	words_.clear();
	Dictionary::const_iterator it = dictionary_->begin();
	for (; it != dictionary_->end(); ++it) {
		const wstring& word = it->first;
		if (selector.isHistogramMatch((*dictionary_)[word])) {
			words_.push_back(&word);
		}
	}
}

