import { Withdrawal } from "./../models/withdrawal";
import { Component } from "@angular/core";
import { WithdrawalService } from "../actions/withdrawalService";
import { WithdrawalRequest } from "../models/withdrawalRequest";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html"
})
export class HomeComponent {
  constructor(private _withdrawalService: WithdrawalService) {
    this.withdrawalRequest = new WithdrawalRequest(null);
    this.withdrawal = new Withdrawal(null);
  }

  public withdrawalRequest: WithdrawalRequest;
  public withdrawal: Withdrawal;
  public errors = new Array();

  async withdrawCash() {
    try {
      this.errors = [];
      this.withdrawal = await this._withdrawalService.postValue(
        this.withdrawalRequest
      );
    } catch (error) {
      this.errors = error.response.data.errors.Amount;
      console.log(this.errors);
    } finally {
      this.withdrawalRequest.amount = null;
    }
  }
}
