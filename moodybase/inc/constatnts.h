#ifndef CONSTATNTS_H_
#define CONSTATNTS_H_

//types
#define TYPE_TOP "top"
#define TYPE_BOT "bot"


// tokens
enum {
    ID, DEFN, OPAR, CPAR, RULE, STMT, CMT
};

#define TOK_DEFN ":"
#define TOK_OPAR "("
#define TOK_CPAR ")"
#define TOK_RULE "::"
#define TOK_STMT ";"
#define TOK_CMT "@"

#define TOK_SPACE " "
#define TOK_COMMA ","
#define TOK_TAB "\t"
#define TOK_INDENT "    "

// commands
#define CMD_DOT "dot"
#define CMD_DOTTY "dotty"
#define CMD_LOAD "load"
#define CMD_DUMP "dump"
#define CMD_STOP "stop"

// command support
#define DOTTY_EXECUTABLE "dotty"
#define DOTTY_DEFAULT_FILTER "dot"

// temp file
#define TMP_FILE "~moody-temp"

// error separator
#define ERR_SEP ":"

#endif /* CONSTATNTS_H_ */
