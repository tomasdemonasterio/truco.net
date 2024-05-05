namespace PlayerNS {
    using HandNS;

    class Player {
        private string name;
        private Hand hand;
        private int score;
        private int roundScore;
        
        

        public Player(string name) {
            this.name = name;
            this.hand = new Hand();
            this.score = 0;
            this.roundScore = 0;
        }

        public string GetName() {
            return this.name;
        }

        public Hand GetHand() {
            return this.hand;
        }

        public int GetScore() {
            return this.score;
        }

        public int GetRoundScore() {
            return this.roundScore;
        }

        public void SetRoundScore(int roundScore) {
            this.roundScore = roundScore;
        }

        public void SetScore(int score) {
            this.score = score;
        }

        public void SetHand(Hand hand) {
            this.hand = hand;
        }

    }
}