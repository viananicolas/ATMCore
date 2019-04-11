import axios from "axios";
import { Inject, Injectable } from "@angular/core";
import { Withdrawal } from "../models/withdrawal";
import { WithdrawalRequest } from "../models/withdrawalRequest";

@Injectable()
export class WithdrawalService {
  instance = axios.create({
    baseURL: Inject("BASE_URL")
  });

  postValue = async (data: WithdrawalRequest) => {
    // try {
    //   console.log("funcionou");
    //   const result = await axios.post(`api/atm`, data);
    //   console.log(result);
    //   return result.data;
    // } catch (error) {
    //   console.log(error.response);
    //   return error.response.data.errors;
    // }
    console.log("funcionou");
    const result = await axios.post(`api/atm`, data);
    console.log(result);
    return result.data;
  };
}
