Public Class clsVariables
    Public Const sqlSelect = "SELECT game.season_year, player.full_name, "
    Public Const sqlSelectfrmCompare = ", game.gamekey, game.week, player.position, player.team, game.home_team, game.home_score, game.away_team, game.away_score "
    Public Const sqlSelectSum = "sum(play_player.passing_att), " & _
                    "sum(play_player.passing_cmp), " & _
                    "sum(play_player.passing_int), " & _
                    "sum(play_player.passing_sk), " & _
                    "sum(play_player.passing_tds), " & _
                    "sum(play_player.passing_twoptm), " & _
                    "sum(play_player.passing_yds), " & _
                    "sum(play_player.receiving_rec), " & _
                    "sum(play_player.receiving_yds), " & _
                    "sum(play_player.receiving_tds), " & _
                    "sum(play_player.receiving_twoptm), " & _
                    "sum(play_player.puntret_tds), " & _
                    "sum(play_player.puntret_yds), " & _
                    "sum(play_player.rushing_att), " & _
                    "sum(play_player.rushing_yds), " & _
                    "sum(play_player.rushing_tds), " & _
                    "sum(play_player.rushing_twoptm), " & _
                    "sum(play_player.fumbles_lost), " & _
                    "sum(play_player.fumbles_rec), " & _
                    "sum(play_player.fumbles_rec_tds), " & _
                    "sum(play_player.fumbles_rec_yds), " & _
                    "sum(play_player.fumbles_tot)"
    Public Const sqlSelectPlayer = "SELECT player.player_id, player.full_name, player.first_name, player.last_name, player.team, player.""position"", player.uniform_number, player.college, player.height, player.weight, player.years_pro "
    Public Const sqlFromJoin = " FROM play_player " & _
                    "LEFT JOIN player ON player.player_id = play_player.player_id " & _
                    "LEFT JOIN game ON game.gsis_id = play_player.gsis_id "

    Public Const sqlFromPlayer = "FROM player "
    Public Const sqlGroupOrder = "group by game.season_year, player.full_name " & _
                    "order by game.season_year"
    Public Const sqlGroupOrderLastOpp = "group by game.season_year, game.gamekey, game.week, game.home_team, game.home_score, game.away_team, game.away_score " & _
                    "order by game.season_year, game.gamekey"
    Public Const sqlOrderPlayer = "ORDER BY player.full_name"

    Public Const sqlSelectAll = "select " & _
                    "play_player.gsis_id, " & _
                    "play_player.player_id, " & _
                    "play_player.play_id, " & _
                    "play_player.drive_id, " & _
                    "player.position," & _
                    "play_player.defense_ast AS defense_ast, " & _
                    "play_player.defense_ffum AS defense_ffum, " & _
                    "play_player.defense_fgblk AS defense_fgblk, " & _
                    "play_player.defense_frec AS defense_frec, " & _
                    "play_player.defense_frec_tds AS defense_frec_tds, " & _
                    "play_player.defense_frec_yds AS defense_frec_yds, " & _
                    "play_player.defense_int AS defense_int, " & _
                    "play_player.defense_int_tds AS defense_int_tds, " & _
                    "play_player.defense_int_yds AS defense_int_yds, " & _
                    "play_player.defense_misc_tds AS defense_misc_tds, " & _
                    "play_player.defense_misc_yds AS defense_misc_yds, " & _
                    "play_player.defense_pass_def AS defense_pass_def, " & _
                    "play_player.defense_puntblk AS defense_puntblk, " & _
                    "play_player.defense_qbhit AS defense_qbhit, " & _
                    "play_player.defense_safe AS defense_safe, " & _
                    "play_player.defense_sk AS defense_sk, " & _
                    "play_player.defense_sk_yds AS defense_sk_yds, " & _
                    "play_player.defense_tkl AS defense_tkl, " & _
                    "play_player.defense_tkl_loss AS defense_tkl_loss, " & _
                    "play_player.defense_tkl_loss_yds AS defense_tkl_loss_yds, " & _
                    "play_player.defense_tkl_primary AS defense_tkl_primary, " & _
                    "play_player.defense_xpblk AS defense_xpblk, " & _
                    "play_player.fumbles_forced AS fumbles_forced, " & _
                    "play_player.fumbles_lost AS fumbles_lost, " & _
                    "play_player.fumbles_notforced AS fumbles_notforced, " & _
                    "play_player.fumbles_oob AS fumbles_oob, " & _
                    "play_player.fumbles_rec AS fumbles_rec, " & _
                    "play_player.fumbles_rec_tds AS fumbles_rec_tds, " & _
                    "play_player.fumbles_rec_yds AS fumbles_rec_yds, " & _
                    "play_player.fumbles_tot AS fumbles_tot, " & _
                    "play_player.kicking_all_yds AS kicking_all_yds, " & _
                    "play_player.kicking_downed AS kicking_downed, " & _
                    "play_player.kicking_fga AS kicking_fga, " & _
                    "play_player.kicking_fgb AS kicking_fgb, " & _
                    "play_player.kicking_fgm AS kicking_fgm, " & _
                    "play_player.kicking_fgm_yds AS kicking_fgm_yds, " & _
                    "play_player.kicking_fgmissed AS kicking_fgmissed, " & _
                    "play_player.kicking_fgmissed_yds AS kicking_fgmissed_yds, " & _
                    "play_player.kicking_i20 AS kicking_i20, " & _
                    "play_player.kicking_rec AS kicking_rec, " & _
                    "play_player.kicking_rec_tds AS kicking_rec_tds, " & _
                    "play_player.kicking_tot AS kicking_tot, " & _
                    "play_player.kicking_touchback AS kicking_touchback, " & _
                    "play_player.kicking_xpa AS kicking_xpa, " & _
                    "play_player.kicking_xpb AS kicking_xpb, " & _
                    "play_player.kicking_xpmade AS kicking_xpmade, " & _
                    "play_player.kicking_xpmissed AS kicking_xpmissed, " & _
                    "play_player.kicking_yds AS kicking_yds, " & _
                    "play_player.kickret_fair AS kickret_fair, " & _
                    "play_player.kickret_oob AS kickret_oob, " & _
                    "play_player.kickret_ret AS kickret_ret, " & _
                    "play_player.kickret_tds AS kickret_tds, " & _
                    "play_player.kickret_touchback AS kickret_touchback, " & _
                    "play_player.kickret_yds AS kickret_yds, " & _
                    "play_player.passing_att AS passing_att, " & _
                    "play_player.passing_cmp AS passing_cmp, " & _
                    "play_player.passing_cmp_air_yds AS passing_cmp_air_yds, " & _
                    "play_player.passing_incmp AS passing_incmp, " & _
                    "play_player.passing_incmp_air_yds AS passing_incmp_air_yds, " & _
                    "play_player.passing_int AS passing_int, " & _
                    "play_player.passing_sk AS passing_sk, " & _
                    "play_player.passing_sk_yds AS passing_sk_yds, " & _
                    "play_player.passing_tds AS passing_tds, " & _
                    "play_player.passing_twopta AS passing_twopta, " & _
                    "play_player.passing_twoptm AS passing_twoptm, " & _
                    "play_player.passing_twoptmissed AS passing_twoptmissed, " & _
                    "play_player.passing_yds AS passing_yds, " & _
                    "play_player.punting_blk AS punting_blk, " & _
                    "play_player.punting_i20 AS punting_i20, " & _
                    "play_player.punting_tot AS punting_tot, " & _
                    "play_player.punting_touchback AS punting_touchback, " & _
                    "play_player.punting_yds AS punting_yds, " & _
                    "play_player.puntret_downed AS puntret_downed, " & _
                    "play_player.puntret_fair AS puntret_fair, " & _
                    "play_player.puntret_oob AS puntret_oob, " & _
                    "play_player.puntret_tds AS puntret_tds, " & _
                    "play_player.puntret_tot AS puntret_tot, " & _
                    "play_player.puntret_touchback AS puntret_touchback, " & _
                    "play_player.puntret_yds AS puntret_yds, " & _
                    "play_player.receiving_rec AS receiving_rec, " & _
                    "play_player.receiving_tar AS receiving_tar, " & _
                    "play_player.receiving_tds AS receiving_tds, " & _
                    "play_player.receiving_twopta AS receiving_twopta, " & _
                    "play_player.receiving_twoptm AS receiving_twoptm, " & _
                    "play_player.receiving_twoptmissed AS receiving_twoptmissed, " & _
                    "play_player.receiving_yac_yds AS receiving_yac_yds, " & _
                    "play_player.receiving_yds AS receiving_yds, " & _
                    "play_player.rushing_att AS rushing_att, " & _
                    "play_player.rushing_loss AS rushing_loss, " & _
                    "play_player.rushing_loss_yds AS rushing_loss_yds, " & _
                    "play_player.rushing_tds AS rushing_tds, " & _
                    "play_player.rushing_twopta AS rushing_twopta, " & _
                    "play_player.rushing_twoptm AS rushing_twoptm, " & _
                    "play_player.rushing_twoptmissed AS rushing_twoptmissed, " & _
                    "play_player.rushing_yds AS rushing_yds"

End Class
