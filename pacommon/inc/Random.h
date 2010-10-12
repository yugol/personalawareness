#ifndef RANDOM_H_
#define RANDOM_H_

class Random {
public:
	Random();
	virtual ~Random();

	bool nextBool() const;
	int nextInt() const;
	int nextInt(int max) const;
	int nextInt(int min, int max) const;
};

#endif /* RANDOM_H_ */
