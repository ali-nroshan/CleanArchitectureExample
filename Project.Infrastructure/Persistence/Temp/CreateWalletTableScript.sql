CREATE TABLE "Wallets" (
	"WalletId"	TEXT NOT NULL UNIQUE,
	"WalletBalance"	INTEGER NOT NULL,
	"WalletCreateDate"	TEXT NOT NULL,
	PRIMARY KEY("WalletId")
);