export class Withdrawal {
  constructor(amount: number) {
    this.twoReaisAmount = amount;
    this.fiveReaisAmount = amount;
    this.tenReaisAmount = amount;
    this.twentyReaisAmount = amount;
    this.fiftyReaisAmount = amount;
    this.hundredReaisAmount = amount;
  }
  twoReaisAmount: number;
  fiveReaisAmount: number;
  tenReaisAmount: number;
  twentyReaisAmount: number;
  fiftyReaisAmount: number;
  hundredReaisAmount: number;
  message: string;
}
