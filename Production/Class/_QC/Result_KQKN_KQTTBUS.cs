﻿namespace Production.Class
{
    public class Result_KQKN_KQTTBUS
    {
        private Result_KQKN_KQTTDAO DAO = new Result_KQKN_KQTTDAO();

        public void Result_KQKN_KQTTBUS_INSERT(Result_KQKN_KQTT OBJ)
        {
            DAO.Result_KQKN_KQTTDAO_INSERT(OBJ);
        }

        public void Result_KQKN_KQTTBUS_UPDATE(Result_KQKN_KQTT OBJ)
        {
            DAO.Result_KQKN_KQTTDAO_UPDATE(OBJ);
        }

        public void Result_KQKN_KQTTBUS_DELETE(Result_KQKN_TD OBJ)
        {
            DAO.Result_KQKN_KQTTDAO_DELETE(OBJ);
        }

        public void Result_KQKN_KQTTDAO_UPDATE_KQTT_VALUE(Result_KQKN_KQTT OBJ)
        {
            DAO.Result_KQKN_KQTTDAO_UPDATE_KQTT_VALUE(OBJ);
        }
    }
}